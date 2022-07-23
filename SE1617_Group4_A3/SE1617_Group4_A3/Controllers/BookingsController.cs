using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE1617_Group4_A3.Models;

namespace SE1617_Group4_A3.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CinemaContext _context;

        public BookingsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index(int id)
        {

            Show show = _context.Shows.Find(id);
            Room room = _context.Rooms.Find(show.RoomId);
            if (show == null || room == null)
            {
                return NotFound();
            }

            List<Booking> listBooking = await _context.Bookings.Where(b => b.ShowId == show.ShowId).ToListAsync();

            List<char[]> listBooked = new List<char[]>();

            string seat = "";
            for (int i = 0; i < room.NumberRows * room.NumberCols; i++)
            {
                seat += '0';
            }
            if (listBooking.Count == 0)
            {

                listBooked.Add(seat.ToCharArray());
            }
            else
            {
                char[] chars = seat.ToCharArray();
                foreach (Booking item in listBooking)
                {
                    for (int i = 0; i < item.SeatStatus.Length; i++)
                    {
                        if (item.SeatStatus[i] == '1')
                        {
                            chars[i] = '1';
                        }
                    }
                }
                listBooked.Add(chars);
            }


            ViewData["listBooked"] = listBooked;
            ViewData["Room"] = room;
            ViewData["listBooking"] = listBooking;
            Booking booking = new Booking();
            booking.BookingId = id;
            return View(booking);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int idBooking, int idShow)
        {
            Show show = await _context.Shows.FindAsync(idShow);
            Room room = await _context.Rooms.FindAsync(show.RoomId);
            Booking booking = await _context.Bookings.FindAsync(idBooking);

            if (show == null || room == null || booking == null)
            {
                return NotFound();
            }
            List<char[]> listBooked = new List<char[]>();
            listBooked.Add(booking.SeatStatus.ToCharArray());
            ViewData["Room"] = room;
            ViewData["listBooked"] = listBooked;

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create(int id)
        {
            Show show = _context.Shows.Find(id);
            Room room = _context.Rooms.Find(show.RoomId);
            if (show == null || room == null)
            {
                return NotFound();
            }

            List<Booking> listBooking = _context.Bookings.Where(b => b.ShowId == show.ShowId).ToList();

            List<char[]> listBooked = new List<char[]>();
            string seat = "";
            for (int i = 0; i < room.NumberRows * room.NumberCols; i++)
            {
                seat += '0';
            }

            if (listBooking.Count == 0)
            {

                listBooked.Add(seat.ToCharArray());
            }
            else
            {
                char[] chars = seat.ToCharArray();
                foreach (Booking item in listBooking)
                {
                    for (int i = 0; i < item.SeatStatus.Length; i++)
                    {
                        if (item.SeatStatus[i] == '1')
                        {
                            chars[i] = '1';
                        }
                    }
                }

                listBooked.Add(chars);
            }
            ViewData["listBooked"] = listBooked;
            ViewData["Room"] = room;
            ViewData["Price"] = (long)show.Price;
            Booking booking = new Booking();
            booking.BookingId = id;
            return View(booking);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection f)
        {
            string id = f["idShows"];
            string[] seats = f["seats"];
            string name = f["name"];
            string price = f["price"];
            if (seats.Length == 0)
            {
                return Content("Please Select Seat!");
            }
            Show show = _context.Shows.Find(Convert.ToInt32(id.Trim()));
            Room room = _context.Rooms.Find(show.RoomId);
            string seatStatus = "";
            for (int i = 0; i < room.NumberRows * room.NumberCols; i++)
            {
                bool flag = false;
                foreach (string item in seats)
                {
                    if (i == Convert.ToInt32(item.Trim()))
                    {
                        seatStatus += '1';
                        flag = true;
                    }
                }
                if (!flag)
                {
                    seatStatus += '0';
                }
            }
            Booking booking = new Booking
            {
                Name = name,
                SeatStatus = seatStatus,
                Amount = Convert.ToDecimal(price.Trim()),
                ShowId = Convert.ToInt32(id.Trim())
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            Booking modelBooking = new Booking
            {
                BookingId = Convert.ToInt32(id.Trim())
            };
            TempData["message"] = "Create A Booking Successfull!";
            return RedirectToAction(nameof(Index), new { id = modelBooking.BookingId });
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? idBooking, int idShow)
        {
            if (idBooking == null)
            {
                return NotFound();
            }
            Show show = await _context.Shows.FindAsync(idShow);
            Room room = await _context.Rooms.FindAsync(show.RoomId);
            var booking = await _context.Bookings.FindAsync(idBooking);
            if (booking == null)
            {
                return NotFound();
            }

            List<Booking> listBooking = _context.Bookings.Where(b => b.BookingId != idBooking && b.ShowId == idShow).ToList();
            List<char[]> listBooked = new List<char[]>();
            string seats_raw = "";
            for (int i = 0; i < room.NumberRows * room.NumberCols; i++)
            {
                seats_raw += "0";
            }


            if (listBooking.Count != 0)
            {
                char[] seatsExist = seats_raw.ToCharArray();
                foreach (Booking item in listBooking)
                {
                    for (int j = 0; j < item.SeatStatus.Length; j++)
                    {
                        if (item.SeatStatus[j] == '1')
                        {
                            seatsExist[j] = '1';
                        }
                    }
                }
                listBooked.Add(seatsExist);
            } else
            {
                listBooked.Add(seats_raw.ToCharArray());
            }
            ViewData["listBooked"] = listBooked;

            ViewData["currentBooking"] = booking.SeatStatus;
            ViewData["Room"] = room;
            ViewData["idShow"] = idShow;
            ViewData["Price"] = show.Price;
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string[] seats, int BookingId, int ShowId, string Name, decimal Amount)
        {

            if (BookingId > 0)
            {
                try
                {
                    Show show = await _context.Shows.FindAsync(ShowId);
                    Room room = await _context.Rooms.FindAsync(show.RoomId);
                    string newSeats = "";
                    for (int i = 0; i < room.NumberRows * room.NumberCols; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j < seats.Length; j++)
                        {
                            if (Convert.ToInt32(seats[j].Trim()) == i)
                            {
                                newSeats += "1";
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            newSeats += "0";
                        }
                    }
                    Booking booking = await _context.Bookings.FindAsync(BookingId);
                    booking.Name = Name;
                    booking.Amount = Amount;
                    booking.SeatStatus = newSeats;
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["message"] = "Edit A Booking Successfull!";
                return RedirectToAction(nameof(Index), new { id = ShowId });
            }
            //ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "ShowId", booking.ShowId);
            return NotFound();
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int idBooking, int idShow)
        {
            Show show = await _context.Shows.FindAsync(idShow);
            Room room = await _context.Rooms.FindAsync(show.RoomId);
            Booking booking = await _context.Bookings.FindAsync(idBooking);
            List<char[]> listBooked = new List<char[]>();
            listBooked.Add(booking.SeatStatus.ToCharArray());

            ViewData["listBooked"] = listBooked;
            ViewData["Room"] = room;
            ViewData["idShow"] = idShow;
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BookingId, int ShowId)
        {
            var booking = await _context.Bookings.FindAsync(BookingId);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete A Booking Successfull!";
            return RedirectToAction(nameof(Index), new { id = ShowId });
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
