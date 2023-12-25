using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using scoremaster_Presentation.ViewModel;
using System.Security.Claims;

namespace scoremaster_Presentation.Controllers
{
    public class EventController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public EventController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        public IActionResult EventList()
        {
           var Event =_context.Event.ToList();
            return View(Event);
        }
      //  [Authorize(Policy = "Event.Create")]
        [HttpGet]
        public IActionResult EventCreate()

        {
            ViewBag.DeptList = _context.Departments.ToList();
            ViewBag.Rubrics = _context.RubricCreates.ToList();

            Event Even = new Event();
            return View(Even);
          
        }
        
        [HttpPost]
        public IActionResult EventCreate(Event Events)

        {
            Events.EventDate = DateTime.Now;

            _context.Event.Add(Events);
            _context.SaveChanges();
            return RedirectToAction(nameof(EventList));
        }
   //   //  [Authorize(Policy = "Event.Join")]
        [HttpGet]
        public IActionResult JoinEvent(int Id)
        {
           
            var Groups = _context.Groups.ToList();
            return View(Groups );

           
        }

        [HttpGet]
        public IActionResult ExamianerJoinEvent(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var exam = _context.ExternalUserscs.Where(x => x.ExternalUserscsId == uIdint).FirstOrDefault();

            var Groups = _context.Groups.Where(x=>x.EventId== exam.EventId).ToList();
            return View(Groups);


        }

        public async Task< IActionResult> ExamianerMembermarking(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var exam = _context.ExternalUserscs.Where(x => x.ExternalUserscsId == uIdint).FirstOrDefault();

            
            ViewBag.UserId = exam?.ExternalUserscsId;
            ViewBag.id = Id;

            RubricDesignVm Vm = new RubricDesignVm();
            Vm.Group = _context.Groups.Where(x => x.GroupId == Id).FirstOrDefault();
            Vm.Members = _context.MemberDatas.Where(x => x.GroupId == Id).ToList();
            var event1 = _context.Event.Where(x => x.EventId == Vm.Group.EventId).FirstOrDefault();
            ViewBag.eventid = event1.EventId;
            ViewBag.markslist = _context.Marks.Where(X => X.EventId == event1.EventId && X.ExternalUserscsId == exam.ExternalUserscsId).ToList();
            ViewBag.rubriclevel =await (from a in _context.RubricCreates
                                        join b in _context.ProgramlearingOutcomes on a.RubricCreateId equals b.RubricCreateId into Programlearing
                                        from Programlearings in Programlearing.DefaultIfEmpty()
                                        join c in _context.EvaluationCriteria on Programlearings.ProgramlearingOutcomesId equals c.ProgramlearingOutcomesId into EvaluationCriteria
                                        from EvaluationCriterias in EvaluationCriteria.DefaultIfEmpty()
                                        join d in _context.EvaluationLevels on EvaluationCriterias.EvaluationCriteriaId equals d.EvaluationCriteriaId into EvaluationLevel
                                        from EvaluationLevels in EvaluationLevel.DefaultIfEmpty()
                                        where a.RubricCreateId == exam.RubricCreateId
                                        select new RubricDesignVm
                                        {
                                            PlO = Programlearings.Name,
                                            PloDescription = EvaluationCriterias.Name,
                                            PloMarks = Convert.ToInt32(EvaluationCriterias.TotalMarks),
                                            PLOType = EvaluationCriterias.Type,
                                            poor = EvaluationLevels.Poor,
                                            BelowAverage = EvaluationLevels.BelowAverae,
                                            AboveAverage = EvaluationLevels.AboveAverae,
                                            Excellent = EvaluationLevels.Excellent,
                                            EvaluationLevelId = EvaluationLevels.EvaluationLevelId
                                        }).Distinct().ToListAsync();
            return View(Vm);


        }
        [HttpPost]
        public async Task<IActionResult> ExamianerMembermarking(RubricDesignVm vm, int Groupid)
        {
            int evlid = 0;
            Marks marks = new Marks();
            foreach (var item in vm.Marks)
            {
                marks.EvaluationLevels = await _context.EvaluationLevels.FindAsync(item.EvaluationLevelId);
                evlid = marks.EvaluationLevels.EvaluationLevelId;
                if (item.TotalMarks != null)
                {
                    var member = _context.Marks.Where(x => x.MemberDataId == item.MemberDataId && x.ExternalUserscsId== item.ExternalUserscsId && x.EvaluationLevels.EvaluationLevelId == item.EvaluationLevelId && x.EventId == item.EventId).FirstOrDefault();
                    if (member != null)
                    {
                        member.TotalMarks = item.TotalMarks;
                        _context.Marks.Attach(member);
                        _context.Entry(member).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        marks.MarksId = 0;
                        marks.TotalMarks = item.TotalMarks;
                        marks.EventId = item.EventId;
                        marks.ExternalUserscsId = item.ExternalUserscsId;
                        marks.MemberDataId = item.MemberDataId;
                        marks.EvaluationLevelId = evlid;
                        _context.Marks.Add(marks);
                        await _context.SaveChangesAsync();
                    }

                }
            }
            return RedirectToAction("ExamianerMembermarking", new { Id = Groupid });
        }
    }
}
