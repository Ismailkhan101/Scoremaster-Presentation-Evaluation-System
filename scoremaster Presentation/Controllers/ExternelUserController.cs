using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using System.Security.Claims;

namespace scoremaster_Presentation.Controllers
{
    public class ExternelUserController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public ExternelUserController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [Authorize(Policy = "ExternalUser")]
        [HttpGet]
        public IActionResult ExternalUser()
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            var ExUsers = _context.ExternalUserscs.Where(x => x.IsActive == false && x.DepartmentId==emp.DepartmentId).ToList();

            return View(ExUsers);
        }
        [Authorize(Policy = "ExternalUserCreate")]
        [HttpGet]
        public IActionResult ExternalUserCreate(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            ViewBag.DeptList = _context.Departments.Where(x=>x.DepartmentId== emp.DepartmentId).ToList();
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
