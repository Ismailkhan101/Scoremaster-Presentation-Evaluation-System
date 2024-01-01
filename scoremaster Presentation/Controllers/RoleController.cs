using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using scoremaster_Presentation.Migrations;
using scoremaster_Presentation.ViewModel;
using scoremaster_Presentation.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace scoremaster_Presentation.Controllers
{
    public class RoleController : Controller
    {
        private readonly ScoreMasterDbContext _context;
        public RoleController(ScoreMasterDbContext context)
        {
            _context = context;


        }
        [Authorize(Policy = "Roles")]
        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            RolesVM roleVM = new RolesVM();
            var roles = await _context.Roles.Where(x => x.IsActive == true).ToListAsync();
            roleVM.roles = roles.Select(x => new RolesList { RoleId = x.ROleId, RoleName = x.RoleName, IsActive = (bool)x.IsActive }).Where(x => x.IsActive == true).ToList();
            foreach (var role in roleVM.roles)
            {
                var permissions = from a in _context.UserPermisions
                                  from b in _context.Permissions
                                  where a.RoleId == role.RoleId && b.PermissionId == a.PermissionId
                                  select new
                                  {
                                      PermissionName = b.PesmissionName
                                  };
                List<string> permiss = new List<string>();
                role.Permission = permissions.Select(x => x.PermissionName).ToList();
            }
            return View(roleVM);
        }

        [Authorize(Policy = "AddRole")]
        [HttpGet]
        public async Task< IActionResult> AddRole()
        {

            RolesVM roles = new RolesVM();
            roles.AddUpdatePermissions = await _context.Permissions.Where(x => x.IsActive == true).Select(x => new scoremaster_Presentation.ViewModel.Permission { PermissionId = x.PermissionId, PermissionName = x.PesmissionName }).ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoles(RolesVM role)
        {

           Roles? Rolen = new Roles();
            Rolen.RoleName= role.RoleName.ToLower();
            await _context.Roles.AddAsync(Rolen);
             _context.SaveChanges();

            var recentRole = await _context.Roles.OrderBy(x => x.ROleId).LastOrDefaultAsync();
                var selectedPermissions = role.AddUpdatePermissions.Where(x => x.isSelected == true).ToList();
            foreach (var permission in selectedPermissions)
            {
                var rolePermissions = new UserPermision();

                rolePermissions.RoleId = recentRole.ROleId;
                rolePermissions.PermissionId = permission.PermissionId;

                await _context.UserPermisions.AddAsync(rolePermissions);
                _context.SaveChanges();
            }



            return RedirectToAction(nameof(Roles));
        }


        [Authorize(Policy = "UpdateRole")]
        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var temp = await _context.Roles.Where(x => x.ROleId == id).FirstOrDefaultAsync();
            var user = new RolesVM
            {
                RoleId = temp.ROleId,
                //IsActive = (bool)temp.IsActive,
                //RoleName = temp.RollName
            };
            user.AddUpdatePermissions = await _context.Permissions.Select(x => new scoremaster_Presentation.ViewModel.Permission { PermissionId = x.PermissionId, PermissionName = x.PesmissionName }).ToListAsync();
            var userPermissions = await _context.UserPermisions.Where(x => x.RoleId == id).ToListAsync();
            foreach (var rolep in user.AddUpdatePermissions)
            {
                foreach (var permission in userPermissions)
                {
                    if (rolep.PermissionId == permission.PermissionId)
                    {
                        rolep.isSelected = true;
                    }
                }
            }
            return View(user);
        }
       
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RolesVM role)
        {
            var temp = await _context.Roles.Where(x => x.ROleId == role.RoleId).FirstOrDefaultAsync();
            if (temp != null)
            {
                var oldPermissions = await _context.UserPermisions.Where(x => x.RoleId == temp.ROleId).ToListAsync();
                _context.UserPermisions.RemoveRange(oldPermissions);
                await _context.SaveChangesAsync();

                var newPermissions = role.AddUpdatePermissions.Where(x => x.isSelected).Select(p => new UserPermision
                {
                    RoleId = temp.ROleId,
                    PermissionId = p.PermissionId
                }).ToList();

                await _context.UserPermisions.AddRangeAsync(newPermissions);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Roles));
        }

    }
}
