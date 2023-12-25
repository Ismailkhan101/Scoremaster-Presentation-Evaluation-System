using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace scoremaster_Presentation.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ScoreMasterDbContext _context;
       
        public HomeController(UserManager<IdentityUser> userManager, ScoreMasterDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
       
    
    public async Task< IActionResult> Index()
        {
            /*var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                string userId = currentUser.Id; // Access the user ID
                                                // Perform actions using the user ID
            }*/
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            var exam = _context.ExternalUserscs.Where(x => x.ExternalUserscsId == uIdint).FirstOrDefault();
            if (emp != null) {
                ViewBag.UserName = emp?.Name;
            }
            else
            {
                ViewBag.UserName = exam?.Name;
            }
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}