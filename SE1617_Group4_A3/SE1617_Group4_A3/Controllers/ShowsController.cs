using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE1617_Group4_A3.Models;

namespace SE1617_Group4_A3.Controllers
{
    public class ShowsController : Controller
    {
        private readonly CinemaContext _context;

        public ShowsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Shows.Include(s => s.Film).Include(s => s.Room).OrderByDescending(s => s.ShowDate);
            ViewData["shows"] = await cinemaContext.ToListAsync();
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title");

            Show show = new Show();
            show.ShowDate = DateTime.Now.Date;
            show.RoomId = _context.Rooms.FirstOrDefault().RoomId;
            return View(show);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Show show)
        {
            var cinemaContext = _context.Shows.Include(s => s.Film).Include(s => s.Room).OrderByDescending(s => s.ShowDate);

            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["shows"] = await cinemaContext
                .Where(s => s.ShowDate == show.ShowDate && s.RoomId == show.RoomId && s.FilmId == show.FilmId)
                .ToListAsync();

            return View(show);
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create(int id)
        {
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", _context.Films.First<Film>().FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", _context.Rooms.First<Room>().RoomId);
            Show show = new Show();
            show.ShowDate = DateTime.Now.Date;
            if(id == 0)
            {
                id = _context.Rooms.First<Room>().RoomId;
            }
            show.RoomId = id;

            List<int> listSlot = GetListSlot(show.ShowDate ?? DateTime.Now.Date, show.RoomId);
            if (listSlot.Count > 0)
            {
                ViewData["Slot"] = new SelectList(listSlot, listSlot[0]);
            }
            return View(show);
        }


        public List<int> GetListSlot(DateTime date, int roomid, int showId = 0)
        {
            bool[] bol = new bool[9];
            List<Show> list = new List<Show>();

            if (showId == 0)
            {
                list = _context.Shows.Where(s => s.ShowDate == date
                    && s.RoomId == roomid)
                .ToList<Show>();
            }
            else
            {
                list = _context.Shows.Where(s => s.ShowDate == date
                    && s.RoomId == roomid
                    && s.ShowId != showId)
                .ToList<Show>();
            }

            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i].Slot ?? -1;
                if (index > 0)
                {
                    bol[index - 1] = true;
                }

            }
            List<int> listSlot = new List<int>();
            for (int i = 0; i < bol.Length; i++)
            {
                if (bol[i] != true)
                {
                    listSlot.Add(i + 1);
                }
            }
            if (listSlot.Count == 0)
            {
                TempData["validate-slot"] = "Slot not available";
            }
            return listSlot;

        }
        [HttpGet, ActionName("SlotAvaiable")]
        public JsonResult SlotAvailable(string date, string roomId)
        {
            DateTime dateSelect = DateTime.Parse(date);
            int room = int.Parse(roomId);
            List<int> list = GetListSlot(dateSelect, room);
            return new JsonResult(list);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,RoomId,FilmId,ShowDate,Price,Status,Slot")] Show show)
        {
            if (ModelState.IsValid)
            {
                show.Status = true;
                _context.Add(show);
                await _context.SaveChangesAsync();
                TempData["message"] = "Add New Show Sucesssfull!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "CountryCode", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            List<int> listSlot = GetListSlot(show.ShowDate ?? DateTime.Now, show.RoomId, id ?? 0);
            if (listSlot.Count > 0)
            {
                ViewData["Slot"] = new SelectList(listSlot, show.Slot);
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,RoomId,FilmId,ShowDate,Price,Status,Slot")] Show show)
        {
            int room = show.RoomId;
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    show.Status = true;
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                    TempData["message"] = "Edit Show Successfull!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
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
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            List<Booking> listBooking = new List<Booking>();
            if (show != null)
            {
                listBooking = await _context.Bookings.Where(b => b.ShowId == id).ToListAsync();
            }
            if (listBooking.Count != 0)
            {
                _context.Bookings.RemoveRange(listBooking);
            }
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete Show Successfull!";
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }
    }
}
