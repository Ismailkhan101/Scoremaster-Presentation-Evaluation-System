using Microsoft.AspNetCore.Mvc;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Migrations;
using Group = scoremaster_Presentation.Models.Group;
using Marks = scoremaster_Presentation.Migrations.Marks;

namespace scoremaster_Presentation.Controllers
{

    public class GroupController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public GroupController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        public IActionResult GroupList()
        {
           var Grouplist=_context.Groups.ToList();
            return View(Grouplist);
        }
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
            group.CoSupervisor = CoSupervisor.Name;
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
            group.CoSupervisor = CoSupervisor.Name;
            group.UsersRegistrationId = Supervisor.UsersRegistrationId;
            group.IsActive = true;

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
        public IActionResult Memberlist(int Id)
        {
            var Memebers = _context.MemberDatas.Where(x => x.GroupId == Id).ToList();
            return View(Memebers);
        }
       
        
    }

}

