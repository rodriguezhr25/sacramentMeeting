﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentalApp.Data;
using SacramentalApp.Models;

namespace SacramentalApp.Controllers
{
    public class SpeechesController : Controller
    {
        private readonly SacramentalAppContext _context;

        public SpeechesController(SacramentalAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(
        string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var speeches = from s in _context.Speech
                           join m in _context.Meeting on s.MeetingId equals m.Id
                           orderby m.Date
                           select new SpeechMeeting { SpeechData = s, MeetingData = m };


            if (!String.IsNullOrEmpty(searchString))
            {
                speeches = speeches.Where(s => s.SpeechData.NameSpeaker.Contains(searchString) 
                ||  s.SpeechData.Topic.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    speeches = speeches.OrderByDescending(s => s.SpeechData.NameSpeaker);
                    break;
                case "Date":
                    speeches = speeches.OrderBy(s => s.MeetingData.Date);
                    break;
                case "date_desc":
                    speeches = speeches.OrderByDescending(s => s.MeetingData.Date);
                    break;
                default:
                    speeches = speeches.OrderBy(s => s.SpeechData.NameSpeaker);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<SpeechMeeting>.CreateAsync(speeches.AsNoTracking(), pageNumber ?? 1, pageSize));

            //   return View(await speeches.ToListAsync());

            //return View(await _context.Speech.ToListAsync());
        }

        // GET: Speeches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speech = await _context.Speech
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speech == null)
            {
                return NotFound();
            }

            return View(speech);
        }

        // GET: Speeches/Create
        public IActionResult Create(int? id)
        {


            ViewData["MId"] = id;



            return View();
        }

        // POST: Speeches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,NameSpeaker,Topic")] Speech speech)
        {
            if (ModelState.IsValid)
            {
                //speech.MeetingId=ViewBag.MId;

                _context.Add(speech);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("EditSpeakers", "Meetings", new { id = speech.MeetingId });
            }
            return View(speech);
            //return RedirectToAction("Details", "Meetings", new { id = speech.MeetingId });


        }

        // GET: Speeches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speech = await _context.Speech.FindAsync(id);
            if (speech == null)
            {
                return NotFound();
            }
            return View(speech);
        }

        // POST: Speeches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingId,NameSpeaker,Topic")] Speech speech)
        {
            if (id != speech.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speech);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeechExists(speech.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("EditSpeakers", "Meetings", new { id = speech.MeetingId });
            }
            return View(speech);
        }

        // GET: Speeches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speech = await _context.Speech
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speech == null)
            {
                return NotFound();
            }

            return View(speech);
            //return RedirectToAction("Details", "Meetings", new { id = speech.MeetingId });
        }

        // POST: Speeches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speech = await _context.Speech.FindAsync(id);
            _context.Speech.Remove(speech);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("EditSpeakers", "Meetings", new { id = speech.MeetingId });
        }

        private bool SpeechExists(int id)
        {
            return _context.Speech.Any(e => e.Id == id);
        }
    }
}
