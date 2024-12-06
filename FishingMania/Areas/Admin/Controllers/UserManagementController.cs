using FishingMania.Controllers;
using FishingMania.Services.Data.Interface_and_services.Admin;
using FishingMania.Services.Data.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserManagementViewModel> allusers= await this.userService.GetAllUsersAsync();
            return this.View(allusers);
        }
    }
}
