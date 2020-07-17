using System;
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

        // GET: Speeches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speech.ToListAsync());
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Speeches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeetingId,NameSpeaker,Topic")] Speech speech)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speech);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speech);
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
                return RedirectToAction(nameof(Index));
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
        }

        // POST: Speeches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speech = await _context.Speech.FindAsync(id);
            _context.Speech.Remove(speech);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeechExists(int id)
        {
            return _context.Speech.Any(e => e.Id == id);
        }
    }
}
