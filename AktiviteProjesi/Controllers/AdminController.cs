using System.Linq.Expressions;
using AktiviteProjesi.Context;
using AktiviteProjesi.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;

namespace AktiviteProjesi.Controllers
{
    public class AdminController : Controller
    {
        private readonly EventDbContext _context;

        
        public AdminController(EventDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult EditEvent(int id)
        {
            var events = _context.Events.Where(x => x.Id == id).FirstOrDefault();

            return View(events);
        }
        [HttpPost]
        public IActionResult EditEvent(Event model)
        {
            var blog = _context.Events.Where(x=> x.Id == model.Id).FirstOrDefault();
            blog.Name= model.Name;
            blog.Description= model.Description;
            blog.Location = model.Location;
            blog.EventImg = model.EventImg;
            _context.SaveChanges();
            return RedirectToAction("Events");
        }

        public IActionResult DeleteEvent(int id)
        {
            var events= _context.Events.Where(x=> x.Id == id).FirstOrDefault();
            _context.Events.Remove(events);
            _context.SaveChanges();
            return RedirectToAction("Events");
        }
        public IActionResult ToggleStatus(int id)
        {
            var events = _context.Events.Where(x => x.Id == id).FirstOrDefault();

            if(events.status == 1)
            {
                events.status = 0;
            }
            else
            {
                events.status = 1;
            }
            _context.SaveChanges();
                return RedirectToAction("Events");
        }
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEvent(Event model)
        {
            
            model.status = 1;
            _context.Events.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Events");
        }

        public IActionResult Comments(int? id)
        {
            var comment = new List<Comment>();
            if(id== null)
            {
                comment = _context.Comments.ToList();
            }
            else
            {
                comment= _context.Comments.Where(x=>x.EventId == id).ToList();
            }
             return View(comment);
        }
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.Where(x=>x.Id == id).FirstOrDefault();
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Comments");
        }
    }
}
