using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using System.Security.Claims;

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
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            var Users = _context.UsersRegistrations.Where(x=>x.IsDeleted==false && x.DepartmentId==emp.DepartmentId).ToList();

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
        [Authorize(Policy = "Changepassword")]
        [HttpGet]
        public IActionResult UserChangePassword( string Message1)
        {
            ViewBag.Message = Message1;
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var Changepass=_context.UsersRegistrations.Where(x=>x.UsersRegistrationId==uIdint).FirstOrDefault();
            ViewBag.UserId = Changepass.UsersRegistrationId;
           ViewBag.password = Changepass.Password;
            return View(Changepass);
        }
        [Authorize(Policy = "Changepassword")]
        [HttpPost]
        public IActionResult UserChangePassword(string NewPassword, int Id)
        {
            var Message="";
            var Changepass = _context.UsersRegistrations.FirstOrDefault(x => x.UsersRegistrationId == Id);
            if (Changepass != null)
            {
                Changepass.Password = NewPassword;
                try
                {
                    _context.UsersRegistrations.Attach(Changepass);
                    _context.Entry(Changepass).State = EntityState.Modified;
                    _context.SaveChanges(); // Fixed method name

                      Message = "Password is changed, New paasword is "+ NewPassword;
                }
                catch (Exception ex)
                {
                    // Handle the exception appropriately, e.g., log the error or provide user feedback
                    ViewBag.ErrorMessage = "An error occurred while saving changes: " + ex.Message;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "User not found!";
            }
            return RedirectToAction(nameof(UserChangePassword) ,new {Message1=  Message });
        }

    }
}
