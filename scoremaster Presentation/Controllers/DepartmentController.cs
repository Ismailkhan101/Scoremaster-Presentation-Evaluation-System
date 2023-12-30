using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public DepartmentController(ScoreMasterDbContext context)
        {
            _context = context;


        }
       [Authorize(Policy = "Department.List")]
        [HttpGet]
        public IActionResult DepartmentList()
        {
            List<Department> Department = _context.Departments.ToList();
            return View(Department);
        }
      [Authorize(Policy = "Department.Create")]
        [HttpGet]
        public IActionResult AddDepartment()
        {
            Department Department = new Department();
            return View(Department);
            
        }
        [HttpPost]
        public IActionResult AddDepartment(Department Departments)
        {
            _context.Departments.Add(Departments);
            _context.SaveChanges();
          return  RedirectToAction(nameof( DepartmentList));

        }
    }
}
