using Microsoft.AspNetCore.Mvc;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace scoremaster_Presentation.Controllers
{

    public class GroupController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public GroupController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [Authorize(Policy = "Group.GroupList")]
        [HttpGet]

        public IActionResult GroupList()
        {
           var Grouplist=_context.Groups.ToList();
            return View(Grouplist);
        }
        [Authorize(Policy = "Group.AddGroup")]
        [HttpGet]
        public IActionResult AddGroup(int Id)
        {
            ViewBag.Supervisor = _context.UsersRegistrations.ToList();
           
            Group Group = new Group();
            var eventli = _context.Event.Where(x => x.EventId == Id).FirstOrDefault();
            ViewBag.IndualGroups = eventli.NoOfGroups;
            var members = _context.Groups.Where(x => x.EventId == Id).ToList();
            ViewBag.MemberCount = members.Count;
            Group.EventId = Id;
            return View(Group);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup(Group group, string memberData)
        {
            int groupid = 0;

            var Supervisor = await _context.UsersRegistrations
                .Where(x => x.UsersRegistrationId == Convert.ToInt32(group.Supervisor))
                .FirstOrDefaultAsync();

            var CoSupervisor = await _context.UsersRegistrations
                .Where(x => x.UsersRegistrationId == Convert.ToInt32(group.CoSupervisor))
                .FirstOrDefaultAsync();

            group.Supervisor = Supervisor.Name;
            if(group.CoSupervisor == null)
            {
                group.CoSupervisor = "Nill";
            }
            else
            {
                group.CoSupervisor = CoSupervisor.Name;

            }
            
            group.UsersRegistrationId = Supervisor.UsersRegistrationId;
            group.IsActive = true;

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            groupid = group.GroupId;

            var members = JsonConvert.DeserializeObject<List<MemberData>>(memberData);

            foreach (var item in members)
            {
                var data = new MemberData
                {
                    MemberName = item.MemberName,
                    MemberCMSID = item.MemberCMSID,
                    GroupId = groupid,
                    IsActive = true
                };

                _context.MemberDatas.Add(data);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("AddGroup", new { Id = group.EventId });
        }

        public IActionResult GroupDecision(int Id)
        {
            var Decision = _context.Event.Where(x => x.EventId == Id).FirstOrDefault();
            if (Decision.GroupIndividual == "Group")
            {
                // Redirect to the "Index" action with the Id parameter
                return RedirectToAction("AddGroup", new { Id = Id });
            }
            else
            {
                // Redirect to the "Index" action with the Id parameter
                return RedirectToAction("IndividualMember", new { Id = Id });
            }
        }
        [Authorize(Policy = "Group.IndividualMember")]
        [HttpGet]
        public IActionResult IndividualMember(int Id)
        {
            ViewBag.Supervisor = _context.UsersRegistrations.ToList();
           
            Group Group = new Group();
            var eventli=_context.Event.Where(x => x.EventId == Id).FirstOrDefault();
            ViewBag.IndualGroups = eventli.NoOfGroups;
            var members=_context.Groups.Where(x => x.EventId ==Id).ToList();
            ViewBag.MemberCount= members.Count;
            Group.EventId = Id;
            return View(Group);
        }
        [HttpPost]
        public async Task<IActionResult> IndividualMember(Group group,String Name,string CMSID)
        {
            int groupid = 0;

            var Supervisor = await _context.UsersRegistrations .Where(x => x.UsersRegistrationId == Convert.ToInt32(group.Supervisor)).FirstOrDefaultAsync();

            var CoSupervisor = await _context.UsersRegistrations .Where(x => x.UsersRegistrationId == Convert.ToInt32(group.CoSupervisor)).FirstOrDefaultAsync();

            group.Supervisor = Supervisor.Name;
            
            group.UsersRegistrationId = Supervisor.UsersRegistrationId;
            group.IsActive = true;
            if(group.CoSupervisor == null)
            {
                group.CoSupervisor = "Nill";
            }
            else
            {
                group.CoSupervisor = CoSupervisor.Name;
            }
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            groupid = group.GroupId;
            MemberData memberData = new MemberData();
            memberData.IsActive = true;
            memberData.MemberName = Name;
            memberData.MemberCMSID = CMSID;
            memberData.GroupId = groupid;
            _context.MemberDatas.Add(memberData);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndividualMember", new { Id = group.EventId });
        }
        [Authorize(Policy = "Group.MemberMarking")]
        [HttpGet]
        public async Task< IActionResult> MemberMarking(int Id)
        {
            var user = User.FindFirst(ClaimTypes.Sid)?.Value;
            int uIdint = Convert.ToInt32(user);
            var emp = _context.UsersRegistrations.Where(x => x.UsersRegistrationId == uIdint).FirstOrDefault();
            ViewBag.UserId= emp?.UsersRegistrationId;
            ViewBag.id = Id;
           
            RubricDesignVm Vm = new RubricDesignVm();
            Vm.Group = _context.Groups.Where(x => x.GroupId == Id).FirstOrDefault();
          Vm.Members = _context.MemberDatas.Where(x => x.GroupId == Id).ToList();
            var event1=_context.Event.Where(x=>x.EventId== Vm.Group.EventId).FirstOrDefault();
            ViewBag.eventid = event1.EventId;
            ViewBag.markslist = _context.Marks.Where(X => X.EventId == event1.EventId && X.UsersRegistrationId == emp.UsersRegistrationId).ToList();
            ViewBag.rubriclevel =  await (from a in _context.RubricCreates
                                                join b in _context.ProgramlearingOutcomes on a.RubricCreateId equals b.RubricCreateId into Programlearing
                                          from Programlearings in Programlearing.DefaultIfEmpty()
                                          join c in _context.EvaluationCriteria on Programlearings.ProgramlearingOutcomesId equals c.ProgramlearingOutcomesId into EvaluationCriteria
                                          from EvaluationCriterias in EvaluationCriteria.DefaultIfEmpty()
                                          join d in _context.EvaluationLevels on EvaluationCriterias.EvaluationCriteriaId equals d.EvaluationCriteriaId into EvaluationLevel
                                          from EvaluationLevels in EvaluationLevel.DefaultIfEmpty()
                                          where a.RubricCreateId == event1.RubricCreateId
                                          select new RubricDesignVm
                                          {
                                              PlO = Programlearings.Name,
                                              PloDescription = EvaluationCriterias.Name,
                                              PloMarks =Convert.ToInt32( EvaluationCriterias.TotalMarks),
                                              PLOType = EvaluationCriterias.Type,
                                              poor= EvaluationLevels.Poor,
                                              BelowAverage= EvaluationLevels.BelowAverae,
                                              AboveAverage= EvaluationLevels.AboveAverae,
                                              Excellent = EvaluationLevels.Excellent,
                                              EvaluationLevelId = EvaluationLevels.EvaluationLevelId
                                          }).Distinct().ToListAsync();
            return View(Vm);
        }
        [HttpPost]
        public async Task< IActionResult> MemberMarking(RubricDesignVm vm ,int Groupid)
        {
            int evlid = 0;
            Marks marks = new Marks();
            foreach (var item in vm.Marks) {
                marks.EvaluationLevels = await _context.EvaluationLevels.FindAsync(item.EvaluationLevelId);
                evlid = marks.EvaluationLevels.EvaluationLevelId;
                if (item.TotalMarks != null)
                {
                    var member=_context.Marks.Where(x=>x.MemberDataId==item.MemberDataId && x.UsersRegistrationId==item.UsersRegistrationId && x.EvaluationLevels.EvaluationLevelId==item.EvaluationLevelId && x.EventId==item.EventId).FirstOrDefault();
                    if(member != null) {
                        member.TotalMarks = item.TotalMarks;
                        _context.Marks.Attach(member);
                        _context.Entry(member).State = EntityState.Modified;
                       await _context.SaveChangesAsync();
                    }
                    else
                    {
                        marks.MarksId = 0;
                        marks.TotalMarks = item.TotalMarks;
                        marks.EventId= item.EventId;
                        marks.UsersRegistrationId= item.UsersRegistrationId;
                        marks.MemberDataId= item.MemberDataId;
                        marks.EvaluationLevelId = evlid;
                        _context.Marks.Add(marks);
                       await  _context.SaveChangesAsync();
                    }
                   
                }
            }
            return RedirectToAction("MemberMarking", new { Id = Groupid });
        }


        }

}

