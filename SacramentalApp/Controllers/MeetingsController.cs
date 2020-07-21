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
    public class MeetingsController : Controller
    {
        private readonly SacramentalAppContext _context;

        public MeetingsController(SacramentalAppContext context)
        {
            _context = context;
        }

        // GET: Meetings
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
            var meetings = from s in _context.Meeting
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(s => s.OpeningSong.Contains(searchString)
                                       || s.CloseningSong.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    meetings = meetings.OrderByDescending(s => s.ConductingLeader);
                    break;
                case "Date":
                    meetings = meetings.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    meetings = meetings.OrderByDescending(s => s.Date);
                    break;
                default:
                    meetings = meetings.OrderBy(s => s.ConductingLeader);
                    break;
            }
     
            int pageSize = 5;
            return View(await PaginatedList<Meeting>.CreateAsync(meetings.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var meeting = await _context.Meeting
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var meeting = await _context.Meeting

            .Include(s => s.Speeches)
   

            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);





            if (meeting == null)
            {
                return NotFound();
            }


            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ConductingLeader,OpeningSong,OpeningPrayer,SacramentHymn,CloseningSong,CloseningPrayer")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ConductingLeader,OpeningSong,OpeningPrayer,SacramentHymn,CloseningSong,CloseningPrayer")] Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.Id))
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
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        /*edit speakers*/
        // GET: Meetings/Details/5
        public async Task<IActionResult> EditSpeakers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting

            .Include(s => s.Speeches)


            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);





            if (meeting == null)
            {
                return NotFound();
            }


            return View(meeting);
        }

        /*end edit speakers*/


        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.Id == id);
        }
    }
}
