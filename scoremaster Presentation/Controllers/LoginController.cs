using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.ViewModel;
using System.Security.Claims;

namespace scoremaster_Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public LoginController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [HttpGet]
        public IActionResult LoginPage( string errormessage, string Loginemail)
        {
            ViewBag.errormessage = errormessage;
            ViewBag.Loginemail= Loginemail;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> LoginPage(LoginVm Login)

        {
            var Empolyee = await _context.UsersRegistrations.Where(x => x.Email == Login.Email && x.Password == Login.Password).FirstOrDefaultAsync();
          var ExternalUser = await _context.ExternalUserscs.Where(x => x.Email == Login.Email && x.Password== Login.Password).FirstOrDefaultAsync();
           

            if (ModelState.IsValid)
            {
                
                    if (Empolyee != null)
                    {

                        var emp = await _context.UsersRegistrations.Where(x => x.Email == Login.Email).FirstOrDefaultAsync();
                        var role = await _context.Roles.Where(x =>x.ROleId == emp.ROleId).FirstOrDefaultAsync();
                        var userPermissions = await _context.UserPermisions.Where(x => x.RoleId == emp.ROleId).ToListAsync();

                        List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, Login.Email),
                        new Claim(ClaimTypes.Sid, Convert.ToString(emp?.UsersRegistrationId)),
                        new Claim("DepartmentId",Convert.ToString(emp?.DepartmentId)),
                        new Claim(ClaimTypes.Role, role.RoleName),
                        new Claim("UserName", emp.Name)
                    };


                        foreach (var perm in userPermissions)
                        {
                            var permission = await _context.Permissions.Where(x => x.PermissionId == perm.PermissionId).FirstOrDefaultAsync();
                            //if (permission.PermissionDbName == null) permission.PermissionDbName = "";
                            var Claim = new Claim("Permission", permission?.PesmissionDbName);
                            claims.Add(Claim);
                        }

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                        {
                            AllowRefresh = true
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                        return RedirectToAction("Index","Home");
                    }
                
               

                //examiner login 
                
                   else if (ExternalUser != null)
                    {

                        var exam = await _context.ExternalUserscs.Where(x => x.Email == Login.Email).FirstOrDefaultAsync();
                        var role = await _context.Roles.Where(x => x.ROleId == exam.ROleId).FirstOrDefaultAsync();
                        var userPermissions = await _context.UserPermisions.Where(x => x.RoleId == exam.ROleId).ToListAsync();

                        List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, Login.Email),
                        new Claim(ClaimTypes.Sid, Convert.ToString(exam?.ExternalUserscsId)),
                        new Claim("DepartmentId",Convert.ToString(exam?.DepartmentId)),
                        new Claim(ClaimTypes.Role, role.RoleName),
                        new Claim("UserName", exam.Name)
                    };


                        foreach (var perm in userPermissions)
                        {
                            var permission = await _context.Permissions.Where(x => x.PermissionId == perm.PermissionId).FirstOrDefaultAsync();
                            //if (permission.PermissionDbName == null) permission.PermissionDbName = "";
                            var Claim = new Claim("Permission", permission?.PesmissionDbName);
                            claims.Add(Claim);
                        }

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                        {
                            AllowRefresh = true
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction(nameof(LoginPage), new { errormessage = "Wrong email or password", Loginemail= Login.Email });
                }


            }

           

            return View("LoginPage");
        }
    }
}
