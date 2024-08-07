﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using scoremaster_Presentation.ViewModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Claims;
 // For ASP.NET MVC
// or using Microsoft.AspNetCore.Mvc; // For ASP.NET Core
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.IO;

namespace scoremaster_Presentation.Controllers
{
    public class EventController : Controller
    {
        
        private readonly ScoreMasterDbContext _context;
        
        public EventController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [Authorize(Policy = "Event.List")]
        public IActionResult EventList()
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            
            var Event =_context.Event.Where(x=>x.DepartmentId==emp.DepartmentId).ToList();
            return View(Event);
            }
        [Authorize(Policy = "Event.Eventactive")]
        public async Task< IActionResult> Eventactive(int id)
        {
            var Event = _context.Event.Where(x => x.EventId== id && x.IsActive==true).FirstOrDefault();
            Event.IsActive = false;
            _context.Event.Attach(Event);
            _context.Entry(Event).State = EntityState.Modified;
          
            var group = _context.Groups.Where(x => x.EventId == id).ToList();
            foreach (var item in group)
            {
                item.IsActive = false;
                _context.Groups.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
              await  _context.SaveChangesAsync();
            }
          await  _context.SaveChangesAsync();
            return RedirectToAction("EventList");
        }
        [Authorize(Policy = "Event.EventInactive")]
        public async Task< IActionResult> EventInactive(int id)
        {
            var Event = _context.Event.Where(x => x.EventId == id && x.IsActive == false).FirstOrDefault();
            Event.IsActive = true;
            _context.Event.Attach(Event);
            _context.Entry(Event).State = EntityState.Modified;
          
            var group=_context.Groups.Where(x=>x.EventId== id && x.IsActive==false).ToList();
            foreach (var item in group)
            {
                item.IsActive = true;
                _context.Groups.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }

          await  _context.SaveChangesAsync();
            return RedirectToAction("EventList");
        }
     [Authorize(Policy = "Event.Create")]
        [HttpGet]
        public IActionResult EventCreate()

        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();

            ViewBag.DeptList = _context.Departments.Where(x=>x.DepartmentId== emp.DepartmentId).ToList();
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
 [Authorize(Policy = "Event.Join")]
        [HttpGet]
    
        public IActionResult JoinEvent(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var empolyee =_context.UsersRegistrations.Where(x=>x.UsersRegistrationId == uIdint).FirstOrDefault();
            var Groups = _context.Groups.Where(x=>x.UsersRegistrationId== empolyee.UsersRegistrationId && x.IsActive==true).ToList();
            return View(Groups );

           
        }
        [Authorize(Policy = "Event.ExamianerJoinEvent")]
        [HttpGet]
        public IActionResult ExamianerJoinEvent(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var exam = _context.ExternalUserscs.Where(x => x.ExternalUserscsId == uIdint).FirstOrDefault();

            var Groups = _context.Groups.Where(x=>x.EventId== exam.EventId).ToList();
            return View(Groups);


        }
        [Authorize(Policy = "Event.ExamianerMembermarking")]
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
      //  [Authorize(Policy = "Event.EventResult")]
        [HttpGet]
        public async Task<IActionResult> EventResult(int id)
        {
           

            var marks = await (
        from a in _context.Marks
        join d in _context.MemberDatas on a.MemberDataId equals d.MemberDataId into MemberMarks
        from Member in MemberMarks.DefaultIfEmpty()
            where a.EventId == id
      //  group new { Member, a } by new { a.MemberDataId, a.TotalMarks } into grouped
        select new
        {
            MemberId = a.MemberDataId,
            Name = Member.MemberName,
            CMSId = Member.MemberCMSID,
            TotalMarks = a.TotalMarks
        }
    )
    .AsNoTracking() // Optional: Use AsNoTracking to improve performance if you don't plan to update the entities
    .ToListAsync();


           ViewBag.MemberResults= marks
       .GroupBy(mark => mark.CMSId)
       .Select(group => new
       {
           Name = group.First().Name,
           CMSId = group.Key,
           TotalMarksSum = group.Sum(mark =>Convert.ToDecimal( mark.TotalMarks))
       })
       .ToList();
            return View();
        }

        [Authorize(Policy = "JoinEventCoordinator")]
        [HttpGet]

        public IActionResult JoinEventCoordinator(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var empolyee = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            var Groups = _context.Groups.Where(x => x.EventId == Id && x.IsActive == true).ToList();
            return View(Groups);


        }
        [Authorize(Policy = "EventSchdule")]
        [HttpGet]
        public async Task<IActionResult> EventSchdule(int Id)
        {
            ViewBag.schdule = await (from a in _context.Event
                                     join b in _context.Groups on a.EventId equals b.EventId into eventsch
                                     from eventschdule in eventsch.DefaultIfEmpty()
                                     join c in _context.MemberDatas on eventschdule.GroupId equals c.GroupId into members
                                     from membersdata in members.DefaultIfEmpty()
                                     where a.EventId == Id
                                     group new
                                     {
                                         MemberName = membersdata != null ? membersdata.MemberName : "NULL",
                                         GroupId = eventschdule != null ? eventschdule.GroupId : (int?)null,
                                         ExternalExaminerName = _context.ExternalUserscs.Where(eu => eu.EventId == a.EventId).Select(eu => eu.Name).ToList()
                                     } by new
                                     {
                                         eventschdule.Title,
                                         eventschdule.dateTime,
                                         eventschdule.Supervisor,
                                         eventschdule.CoSupervisor,
                                         a.EvenSchduled,
                                     } into g
                                     select new
                                     {
                                         EvenSchduled=g.Key.EvenSchduled,
                                         Title = g.Key.Title,
                                         EventDate = g.Key.dateTime,
                                         Supervisor = g.Key.Supervisor,
                                         CoSupervisor = g.Key.CoSupervisor,
                                         ExternalExaminers = g.SelectMany(x => x.ExternalExaminerName).Distinct().ToList(),
                                         Members = g.Select(x => new
                                         {
                                             x.GroupId,
                                             x.MemberName
                                         }).ToList()
                                     }).ToListAsync();



            return View();


        }
      /*  public ActionResult GeneratePDF()
        {
            // Your HTML content (replace with your actual HTML content)
            string htmlContent = @"
            <html>
            <head><title>PDF Generated</title></head>
            <body>
                <h1>Generated PDF from HTML</h1>
                <p>This is a sample PDF generated from HTML content.</p>
            </body>
            </html>
        ";

            // Define the output directory and file name
            string outputDirectory = Server.MapPath("~/Content/PDFs");
            Directory.CreateDirectory(outputDirectory); // Ensure the directory exists
            string outputPath = Path.Combine(outputDirectory, "GeneratedPDF.pdf");

            // Instantiate PDFGenerator class
            PDFGenerator pdfGenerator = new PDFGenerator();

            // Call the GeneratePDF method
            pdfGenerator.GeneratePDF(htmlContent, outputPath);

            // Return an empty result or redirect as needed
            return new EmptyResult();
        }*/
    }
}
