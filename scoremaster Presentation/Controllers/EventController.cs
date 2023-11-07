using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.Controllers
{
    public class EventController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public EventController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        public IActionResult EventList()
        {
           var Event =_context.Event.ToList();
            return View(Event);
        }
      //  [Authorize(Policy = "Event.Create")]
        [HttpGet]
        public IActionResult EventCreate()

        {
            ViewBag.DeptList = _context.Departments.ToList();

           Event Even = new Event();
            return View(Even);
          
        }
        
        [HttpPost]
        public IActionResult EventCreate(Event Events)

        {
            Events.EventDate = DateTime.Now;

            _context.Event.Add(Events);
            _context.SaveChanges();
            return RedirectToAction(nameof(EventList));
        }
   //   //  [Authorize(Policy = "Event.Join")]
        [HttpGet]
        public IActionResult JoinEvent(int Id)
        {
           
            var Groups = _context.Groups.ToList();
            return View(Groups);

           
        }
    }
}
