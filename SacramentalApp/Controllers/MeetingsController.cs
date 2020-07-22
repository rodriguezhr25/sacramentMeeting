using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentalApp.Data;
using SacramentalApp.Models;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;

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
                meetings = meetings.Where(s => s.ConductingLeader.Contains(searchString));
                                   
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
        public async Task<IActionResult> Create([Bind("Id,Date,ConductingLeader,OpeningSong,OpeningPrayer,SacramentHymn,IntermediateHymn,CloseningSong,CloseningPrayer")] Meeting meeting)
        {
            var dateMeeting = await _context.Meeting
           .Include(s => s.Speeches)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.Date == meeting.Date);
            if(dateMeeting != null)
            {
                ModelState.AddModelError(string.Empty, "There exists a register for this date");
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ConductingLeader,OpeningSong,OpeningPrayer,SacramentHymn,IntermediateHymn,CloseningSong,CloseningPrayer")] Meeting meeting)
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

        public async Task<IActionResult> Print(int? id)
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
            var fileName = meeting.Date.ToShortDateString();
            fileName = fileName.Replace('/', '_');
            fileName = "Sacrament_agenda_" + fileName.Replace('-', '_') + ".pdf";
           
            PdfDocument doc = new PdfDocument();
            // Create one page
            PdfPageBase page = doc.Pages.Add();
            //reset the default margins to 0
            doc.PageSettings.Margins = new PdfMargins(0);

            //create a PdfMargins object, the parameters indicate the page margins you want to set
            PdfMargins margins = new PdfMargins(60, 60, 60, 60);

            //create a header template with content and apply it to page template
            doc.Template.Top = CreateHeaderTemplate(doc, margins);

            //apply blank templates to other parts of page template
            doc.Template.Bottom = new PdfPageTemplateElement(doc.PageSettings.Size.Width, margins.Bottom);
            doc.Template.Left = new PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height);
            doc.Template.Right = new PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height);

            //draw text in header space
            //get page size
            SizeF pageSize = doc.PageSettings.Size;
            float x = margins.Left;
            float y = 0;
            float width = page.Canvas.ClientSize.Width;
            float height = page.Canvas.ClientSize.Height;
            float init = pageSize.Width - x - width - 2;
            float end = width - 20;
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            PdfTrueTypeFont fontRegular = new PdfTrueTypeFont(new Font("Garamond", 14f, FontStyle.Regular));
            PdfTrueTypeFont fontBold = new PdfTrueTypeFont(new Font("Garamond", 14f, FontStyle.Bold));
            PdfStringFormat alignLeft = new PdfStringFormat(PdfTextAlignment.Left);
            PdfStringFormat alignRight= new PdfStringFormat(PdfTextAlignment.Right);
            PdfStringFormat alignCenter = new PdfStringFormat(PdfTextAlignment.Center);
            PdfStringFormat alignJustify = new PdfStringFormat(PdfTextAlignment.Justify);
            
            page.Canvas.DrawString("Date: ", fontBold, brush, pageSize.Width - x - width - 2, 40);
            page.Canvas.DrawString(meeting.Date.ToShortDateString(), fontRegular, brush, pageSize.Width - x - width + 30, 40);
            page.Canvas.DrawString("Conducting: ", fontBold, brush, pageSize.Width - x - width - 2, 60);
            page.Canvas.DrawString(meeting.ConductingLeader, fontRegular, brush, pageSize.Width - x - width + 75, 60);
            page.Canvas.DrawString("Opening welcome and acknowledgements", fontBold, brush, width / 2, 80, alignCenter);
            //draw line
            PdfPen pen = new PdfPen(PdfBrushes.Black, 0.5f);
            page.Canvas.DrawLine(pen, init, y + 120, end , y + 120);
            page.Canvas.DrawLine(pen, init, y + 140, end, y + 140);
            page.Canvas.DrawString("Announcements", fontBold, brush, width / 2, 150, alignCenter);
            page.Canvas.DrawLine(pen, init, y + 190, end, y + 190);
            page.Canvas.DrawLine(pen, init, y + 210, end, y + 210);
           
            page.Canvas.DrawString("Opening hymn: ", fontBold, brush, pageSize.Width - x - width - 2, 220);
            page.Canvas.DrawString(meeting.ConductingLeader, fontRegular, brush, pageSize.Width - x - width + 95, 220);
            page.Canvas.DrawString("Invocation: ", fontBold, brush, pageSize.Width - x - width - 2, 240);
            page.Canvas.DrawString(meeting.OpeningPrayer, fontRegular, brush, pageSize.Width - x - width + 95, 240);

            page.Canvas.DrawString("Ward and Stake Bussiness", fontBold, brush, width / 2, 260, alignCenter);
            page.Canvas.DrawLine(pen, init, y + 300, end, y + 300);
            page.Canvas.DrawLine(pen, init, y + 320, end, y + 320);
            page.Canvas.DrawString("Sacrament hymn: ", fontBold, brush, pageSize.Width - x - width - 2, 330);
            page.Canvas.DrawString(meeting.SacramentHymn, fontRegular, brush, pageSize.Width - x - width + 105, 330);
            page.Canvas.DrawString("Speakers", fontBold, brush, width / 2, 350, alignCenter);

            PdfPen pen2 = new PdfPen(PdfBrushes.Black, 1);
            page.Canvas.DrawLine(pen2, init, y + 370, end, y + 370);
            int count = 0;
            int vPosition = 360;
            int totalSpeakers = meeting.Speeches.Count();

            foreach (var item in meeting.Speeches){
                count++;
                string ordinalNumber = "";
                switch (count)
                {
                    case 1:
                        ordinalNumber= count + "st ";
                        break;
                    case 2:
                        ordinalNumber = count + "nd";
                        break;
                    case 3:
                        ordinalNumber = count + "rd";
                        break;
                    default:
                        ordinalNumber = count + "th";
                        break;
                }
                string speaker = ordinalNumber + " Speaker:";
                vPosition = vPosition + 20;
                page.Canvas.DrawString(speaker, fontBold, brush, pageSize.Width - x - width - 2, vPosition );
                page.Canvas.DrawString(item.NameSpeaker, fontRegular, brush, pageSize.Width - x - width + 80, vPosition );
                page.Canvas.DrawString("Topic:", fontBold, brush, width - 300, vPosition, alignRight);
                page.Canvas.DrawString(item.Topic, fontRegular, brush, width - 200, vPosition, alignRight);

                if (count == 2 && meeting.IntermediateHymn != null)
                {
                    vPosition = vPosition + 20;
                    page.Canvas.DrawString("Intermediate Hymn: ", fontBold, brush, pageSize.Width - x - width - 2, vPosition);
                    page.Canvas.DrawString(meeting.SacramentHymn, fontRegular, brush, pageSize.Width - x - width + 125, vPosition);
                }
            }
            page.Canvas.DrawLine(pen2, init, y + vPosition + 20 , end, y + vPosition + 20);
            vPosition = vPosition + 40;
            page.Canvas.DrawString("Closing hymn: ", fontBold, brush, pageSize.Width - x - width - 2, vPosition);
            page.Canvas.DrawString(meeting.CloseningSong, fontRegular, brush, pageSize.Width - x - width + 95, vPosition);
            page.Canvas.DrawString("Benediction: ", fontBold, brush, pageSize.Width - x - width - 2, vPosition + 20);
            page.Canvas.DrawString(meeting.CloseningPrayer, fontRegular, brush, pageSize.Width - x - width + 95, vPosition + 20);
            var path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/PdfFiles", fileName);
            doc.SaveToFile(path);
            doc.Close();
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));           
            
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        private PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top);
            headerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;

            //draw image in header space 
            //var path = Path.Combine(
            // Directory.GetCurrentDirectory(),
            // "wwwroot/images", "logo.jpg");
            //PdfImage headerImage = PdfImage.FromFile(path);
            //float width = headerImage.Width / 3;
            //float height = headerImage.Height / 3;           
            //headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 2, width, height);

            //draw line in header space
            PdfPen pen = new PdfPen(PdfBrushes.Gray, 2);
            headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

            //draw text in header space
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 25f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            String headerText = "SACRAMENT MEETING AGENDA";
            SizeF size = font.MeasureString(headerText, format);
            headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Gray, pageSize.Width - x - size.Width - 2, margins.Top - (size.Height + 5), format);

            //return headerSpace
            return headerSpace;
        }
        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.Id == id);
        }
    }
}
