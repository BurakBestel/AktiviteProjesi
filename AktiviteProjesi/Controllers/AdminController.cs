using System.Linq.Expressions;
using AktiviteProjesi.Context;
using AktiviteProjesi.Identity;
using AktiviteProjesi.Models;
using AktiviteProjesi.Models.ViewModels;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AktiviteProjesi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly EventDbContext _context;
        private readonly UserManager<EventIdentityUser> _userManager;
        private readonly SignInManager<EventIdentityUser> _signInManager;



        public AdminController(EventDbContext context ,UserManager<EventIdentityUser> userManager, SignInManager<EventIdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
            var events = _context.Events.Where(x=> x.Id == model.Id).FirstOrDefault();
            events.Name= model.Name;
            events.Description= model.Description;
            events.Location = model.Location;
            events.EventImg = model.EventImg;
            events.Capacity = model.Capacity;
            events.AvailableSeat = model.AvailableSeat;

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

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> register(RegisterViewModel model)
        {
            if (model.Password == model.RePassword)
            {
                var user = new EventIdentityUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,    
                    UserName= model.Email
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
                
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Event");

        }
        
        public IActionResult Contact()
        {
            var contact = _context.Contacts.ToList();

            return View(contact);
        }
    }
}
