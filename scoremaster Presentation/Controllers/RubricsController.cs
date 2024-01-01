using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Migrations;
using scoremaster_Presentation.Models;
using scoremaster_Presentation.ViewModel;

namespace scoremaster_Presentation.Controllers
{
    public class RubricsController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public RubricsController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [Authorize(Policy = "Rubrics")]
        [HttpGet]
        public IActionResult Rubrics()

        {

            List<Models.RubricCreate> rubricCreates = _context.RubricCreates.ToList();
            return View(rubricCreates);
        }
        [Authorize(Policy = "RubricsCreate")]
        [HttpGet]
        public IActionResult RubricsCreate()

        {

            return View();
        }
        [HttpPost]
        public IActionResult RubricsCreate(Models.RubricCreate rubricCreate)

        {
            rubricCreate.Date=DateTime.Now;
            rubricCreate.IsDeleted = false;
            rubricCreate.Isactive = true;
            _context.RubricCreates.Add(rubricCreate);
            _context.SaveChanges();
            return RedirectToAction(nameof(Rubrics));
           
        }


        [HttpGet]
        public IActionResult RubricsLearingOutcome(int id)

        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult RubricsLearingOutcome(RubricsVM rubricsVM,int RubricId)

        { ProgramlearingOutcome programlearingOutcome=new ProgramlearingOutcome();
            programlearingOutcome.Name = rubricsVM.ProgramlearingOutcomes.Name;
            programlearingOutcome.RubricCreateId = RubricId;
            _context.ProgramlearingOutcomes.Add(programlearingOutcome);
            _context.SaveChanges();
            foreach(var item in rubricsVM.EvaluationCriteria)
            {
                int i = 0;
                EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                evaluationCriteria.Name = item.Name;
                evaluationCriteria.TotalMarks = item.TotalMarks;
                evaluationCriteria.Type = item.Type;
                evaluationCriteria.ProgramlearingOutcomesId = programlearingOutcome.ProgramlearingOutcomesId;
                _context.EvaluationCriteria.Add(evaluationCriteria);
                _context.SaveChanges();
                EvaluationLevels evaluationLevels = new EvaluationLevels();
                evaluationLevels.Poor = rubricsVM.EvaluationLevels[i].Poor;
                evaluationLevels.AboveAverae = rubricsVM.EvaluationLevels[i].AboveAverae;
                evaluationLevels.BelowAverae = rubricsVM.EvaluationLevels[i].BelowAverae;
                evaluationLevels.Excellent = rubricsVM.EvaluationLevels[i].Excellent;
                evaluationLevels.EvaluationCriteriaId= evaluationCriteria.EvaluationCriteriaId;
                _context.EvaluationLevels.Add(evaluationLevels);
                _context.SaveChanges();
                i++;
            }
            return RedirectToAction("RubricsLearingOutcome", new {id = RubricId});
        }
    }
}
