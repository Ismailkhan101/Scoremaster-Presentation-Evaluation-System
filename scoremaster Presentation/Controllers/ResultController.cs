using Microsoft.AspNetCore.Mvc;

namespace scoremaster_Presentation.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult ResultGenerate()
        {
            return View();
        }
    }
}
