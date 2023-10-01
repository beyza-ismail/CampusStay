using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampusStay.Web.Data;
using CampusStay.Web.Models.Domain;

namespace CampusStay.Web.Controllers
{
    public class DormRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DormRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DormRooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DormRooms.Include(d => d.Campus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DormRooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DormRooms == null)
            {
                return NotFound();
            }

            var dormRoom = await _context.DormRooms
                .Include(d => d.Campus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dormRoom == null)
            {
                return NotFound();
            }

            return View(dormRoom);
        }

        // GET: DormRooms/Create
        public IActionResult Create()
        {
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Id");
            return View();
        }

        // POST: DormRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomName,RoomImage,RoomDescription,Price,Rating,CampusId")] DormRoom dormRoom)
        {
            if (ModelState.IsValid)
            {
                dormRoom.Id = Guid.NewGuid();
                _context.Add(dormRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Id", dormRoom.CampusId);
            return View(dormRoom);
        }

        // GET: DormRooms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DormRooms == null)
            {
                return NotFound();
            }

            var dormRoom = await _context.DormRooms.FindAsync(id);
            if (dormRoom == null)
            {
                return NotFound();
            }
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Id", dormRoom.CampusId);
            return View(dormRoom);
        }

        // POST: DormRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RoomName,RoomImage,RoomDescription,Price,Rating,CampusId")] DormRoom dormRoom)
        {
            if (id != dormRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dormRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DormRoomExists(dormRoom.Id))
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
            ViewData["CampusId"] = new SelectList(_context.Campuses, "Id", "Id", dormRoom.CampusId);
            return View(dormRoom);
        }

        // GET: DormRooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DormRooms == null)
            {
                return NotFound();
            }

            var dormRoom = await _context.DormRooms
                .Include(d => d.Campus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dormRoom == null)
            {
                return NotFound();
            }

            return View(dormRoom);
        }

        // POST: DormRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DormRooms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DormRooms'  is null.");
            }
            var dormRoom = await _context.DormRooms.FindAsync(id);
            if (dormRoom != null)
            {
                _context.DormRooms.Remove(dormRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DormRoomExists(Guid id)
        {
          return (_context.DormRooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
