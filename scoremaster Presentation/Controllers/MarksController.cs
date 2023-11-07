using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
namespace scoremaster_Presentation.Controllers
{
    public class MarksController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public MarksController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        public IActionResult Marks(int Id)
        {
           
        var Marks = _context.Marks.Where(x => x.UsersRegistrationId == Id).ToList();
            return View(Marks);
        }
        public IActionResult MarksCreate(int Id)
        {

            Marks Marks =new Marks();
            Marks.MemberDataId= Id;
            return View(Marks);
        }
        [HttpPost]
        public IActionResult MarksCreate(Marks marks)
        {

          _context.Marks.Add(marks);
          _context.SaveChanges();
            return RedirectToAction("EventList", "Event");
        }
    }
}
