using FishingMania.Controllers;
using FishingMania.Services.Data.Interface_and_services.Admin;
using FishingMania.Services.Data.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FishingMania.Common.ValidationConstant;

namespace FishingMania.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserManagementController:BaseController

    {
        private readonly IUserService userService;
        public UserManagementController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserManagementViewModel> allusers= await this.userService.GetAllUsersAsync();
            return this.View(allusers);
        }
       

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {

            bool userExists = await this.userService
                .UserExistsByIdAsync(userId);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool assignResult = await this.userService
                .AssignUserToRoleAsync(userId, role);
            if (!assignResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            
            bool userExists = await this.userService
                .UserExistsByIdAsync(userId);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool removeResult = await this.userService
                .RemoveUserRoleAsync(userId, role);
            if (!removeResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {

            bool userExists = await this.userService
                .UserExistsByIdAsync(userId);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool removeResult = await this.userService
                .DeleteUserAsync(userId);
            if (!removeResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
