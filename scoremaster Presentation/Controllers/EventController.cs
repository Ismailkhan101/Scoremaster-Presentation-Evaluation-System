using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using System.Security.Claims;

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
            ViewBag.Rubrics = _context.RubricCreates.ToList();

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
            return View(Groups );

           
        }

        [HttpGet]
        public IActionResult ExamianerJoinEvent(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var exam = _context.ExternalUserscs.Where(x => x.ExternalUserscsId == uIdint).FirstOrDefault();

            var Groups = _context.Groups.Where(x=>x.EventId== exam.EventId).ToList();
            return View(Groups);


        }
    }
}
