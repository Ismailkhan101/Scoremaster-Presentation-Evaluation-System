using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public RegistrationController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [Authorize(Policy = "Users")]
        [HttpGet]
        public IActionResult Users()
        {
            var Users = _context.UsersRegistrations.Where(x=>x.IsDeleted==false).ToList();    

            return View(Users);
        }
        [Authorize(Policy = "UserRegisterCreate")]
        [HttpGet]
        public IActionResult UserRegisterCreate()
        {
            ViewBag.DeptList=_context.Departments.ToList();
            ViewBag.Role= _context.Roles.ToList();

            UsersRegistration UsersRegistration = new UsersRegistration();
            return View(UsersRegistration);
        }
        [Authorize(Policy = "UserRegisterCreate")]
        [HttpPost]
        public IActionResult UserRegisterCreate(UsersRegistration UsersRegistrations)
        {
            _context.UsersRegistrations.Add(UsersRegistrations);
            _context.SaveChanges();
            return RedirectToAction(nameof(UserRegisterCreate));
        }
    }
}
