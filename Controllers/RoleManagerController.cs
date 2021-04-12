using FagElGamous.Models;
using FagElGamous.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Controllers
{
    [Authorize(Policy = "deletepolicy")]
    public class RoleManagerController : Controller
    {
        private PolicyRolesDbContext _policyRolesContext { get; set; }
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerController(RoleManager<IdentityRole> roleManager, PolicyRolesDbContext context)
        {
            _roleManager = roleManager;
            _policyRolesContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var writeRoles = new List<WriteRole>();
            var deleteRoles = new List<DeleteRole>();
            if (_policyRolesContext.WriteRoles.Count() > 0)
            {
                writeRoles = _policyRolesContext.WriteRoles.ToList();
            }
            if (_policyRolesContext.DeleteRoles.Count() > 0)
            {
                deleteRoles = _policyRolesContext.DeleteRoles.ToList();
            }

            return View(new PolicyRolesViewModel
            {
                Roles = roles,
                WriteRoles = writeRoles,
                DeleteRoles = deleteRoles
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View();
            }
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Unable to delete role");
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ManageWriteGroup(string roleName)
        {
            if (ModelState.IsValid)
            {
                foreach (var role in _policyRolesContext.WriteRoles)
                {
                    if (roleName == role.Role)
                    {
                        ModelState.AddModelError("", "Role already in group");
                        return RedirectToAction("Index");
                    }
                }
                WriteRole wr = new WriteRole { Role = roleName };
                _policyRolesContext.WriteRoles.Add(wr);
                _policyRolesContext.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult WriteRoleDelete(int roleId)
        {
            var role = _policyRolesContext.WriteRoles.FirstOrDefault(r => r.WriteRoleId == roleId);
            _policyRolesContext.WriteRoles.Remove(role);
            _policyRolesContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ManageDeleteGroup(string roleName)
        {
            if (ModelState.IsValid)
            {
                foreach (var role in _policyRolesContext.DeleteRoles)
                {
                    if (roleName == role.Role)
                    {
                        ModelState.AddModelError("", "Role already in group");
                        return RedirectToAction("Index");
                    }
                }
                DeleteRole dr = new DeleteRole { Role = roleName };
                _policyRolesContext.DeleteRoles.Add(dr);
                _policyRolesContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult DeleteRoleDelete(int roleId)
        {
            var role = _policyRolesContext.DeleteRoles.FirstOrDefault(r => r.DeleteRoleId == roleId);
            _policyRolesContext.DeleteRoles.Remove(role);
            _policyRolesContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
