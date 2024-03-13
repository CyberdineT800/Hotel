using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly AppDbContext dbContext;

        public RoomController(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            List<Room> rooms = dbContext.Rooms.ToList();
            return View(rooms);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Room");
            }
            return View(room);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var room = dbContext.Rooms.Find(id);
            if (room is null)
            {
                return NotFound();
            }
            return View(room);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var room = dbContext.Rooms.Find(id);
            if (room is null)
            {
                return NotFound();
            }
            return View(room);
        }
        [HttpPost]
        public IActionResult Delete(Room room)
        {
            if (room is null)
            {
                return NotFound();
            }
            dbContext.Rooms.Remove(room);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Room");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = dbContext.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.RoomTypes = GetRoomTypes(); // Pass room types to the view
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                var dbRoom = dbContext.Rooms.Find(room.Id);

                if (dbRoom != null)
                {
                    dbRoom.RoomNumber = room.RoomNumber;
                    dbRoom.IsAvailable = room.IsAvailable;
                    dbRoom.PricePerNight = room.PricePerNight;
                    dbRoom.RoomType = room.RoomType;

                    dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

            ViewBag.RoomTypes = GetRoomTypes(); 
            return View(room);
        }

        private List<SelectListItem> GetRoomTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Standard", Text = "Standard" },
                new SelectListItem { Value = "Deluxe", Text = "Deluxe" },
                new SelectListItem { Value = "Suite", Text = "Suite" }
            };
        }
    }
}
