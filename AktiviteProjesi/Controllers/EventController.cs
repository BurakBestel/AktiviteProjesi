using AktiviteProjesi.Context;
using AktiviteProjesi.Identity;
using AktiviteProjesi.Models;
using AktiviteProjesi.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AktiviteProjesi.Controllers
{
    public class EventController : Controller
    {
        private readonly EventDbContext _context;
        
        public EventController(EventDbContext context)
        {
            _context = context;
           
        }

        public IActionResult Index()
        {
            var blogs = _context.Events.ToList();
            return View(blogs);
        }

        public IActionResult Details(int id)
        {

            var Event = _context.Events.Where(x => x.Id == id).FirstOrDefault();
            var comments = _context.Comments.Where(x => x.EventId == id).ToList();
            ViewBag.Comments = comments.ToList();
            
            return View(Event);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment model)
        {
            model.PublishDate = DateTime.Now;
            _context.Comments.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Details", new {id =model.EventId});
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(Contact model)
        {
            model.CreatedDate = DateTime.Now;
            _context.Contacts.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        

        
        
    }
}
