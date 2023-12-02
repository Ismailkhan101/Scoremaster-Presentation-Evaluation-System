using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.Controllers
{
    public class ExternelUserController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public ExternelUserController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [HttpGet]
        public IActionResult ExternalUser()
        {
            var ExUsers = _context.ExternalUserscs.Where(x => x.IsActive == false).ToList();

            return View(ExUsers);
        }
        [HttpGet]
        public IActionResult ExternalUserCreate(int Id)
        {
            ViewBag.DeptList = _context.Departments.ToList();
            ViewBag.Role = _context.Roles.ToList();
            ViewBag.Rubrics = _context.RubricCreates.ToList();
            ExternalUserscs ExternalUser = new ExternalUserscs();
            ExternalUser.EventId = Id;
            return View(ExternalUser);
        }
        [HttpPost]
        public IActionResult ExternalUserCreate(ExternalUserscs ExternalUserscs)
        {
            _context.ExternalUserscs.Add(ExternalUserscs);
            _context.SaveChanges();
            return RedirectToAction("EventList", "Event", new { Id = ExternalUserscs.EventId });

        }
    }
}
