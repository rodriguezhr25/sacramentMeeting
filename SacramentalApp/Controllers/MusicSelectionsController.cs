using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SacramentalApp.Data;
using SacramentalApp.Models;

namespace SacramentalApp.Controllers
{
    public class MusicSelectionsController : Controller
    {
        private readonly SacramentalAppContext _context;

        public MusicSelectionsController(SacramentalAppContext context)
        {
            _context = context;
        }

        // GET: MusicSelections
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["HymnNumberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "hymnNumber_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var musicSelections = from ms in _context.MusicSelection
                                  select ms;

            if (!String.IsNullOrEmpty(searchString))
            {
                musicSelections = musicSelections.Where(ms => ms.Name.Contains(searchString) || ms.HymnNumber.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "hymnNumber_desc":
                    musicSelections = musicSelections.OrderByDescending(ms => ms.HymnNumber);
                    break;
                case "Name":
                    musicSelections = musicSelections.OrderBy(ms => ms.Name);
                    break;
                case "name_desc":
                    musicSelections = musicSelections.OrderByDescending(ms => ms.Name);
                    break;
                default:
                    musicSelections = musicSelections.OrderBy(ms => ms.HymnNumber);
                    break;
            }

            int pageSize = 10; // Number of items per page
            return View(await PaginatedList<MusicSelection>.CreateAsync(musicSelections.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: MusicSelections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicSelection = await _context.MusicSelection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicSelection == null)
            {
                return NotFound();
            }

            return View(musicSelection);
        }

        // GET: MusicSelections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicSelections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HymnNumber,Name")] MusicSelection musicSelection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicSelection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicSelection);
        }

        // GET: MusicSelections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicSelection = await _context.MusicSelection.FindAsync(id);
            if (musicSelection == null)
            {
                return NotFound();
            }
            return View(musicSelection);
        }

        // POST: MusicSelections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HymnNumber,Name")] MusicSelection musicSelection)
        {
            if (id != musicSelection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicSelection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicSelectionExists(musicSelection.Id))
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
            return View(musicSelection);
        }

        // GET: MusicSelections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicSelection = await _context.MusicSelection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicSelection == null)
            {
                return NotFound();
            }

            return View(musicSelection);
        }

        // POST: MusicSelections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicSelection = await _context.MusicSelection.FindAsync(id);
            if (musicSelection != null)
            {
                _context.MusicSelection.Remove(musicSelection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicSelectionExists(int id)
        {
            return _context.MusicSelection.Any(e => e.Id == id);
        }
    }
}