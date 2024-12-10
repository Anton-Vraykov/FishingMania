

using FishingMania.Services.Data.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FishingMania.Services.Data.Interface_and_services.Admin
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IEnumerable<UserManagementViewModel>> GetAllUsersAsync()
        {
            IEnumerable<IdentityUser> allUser=await userManager.Users.ToArrayAsync();
            ICollection<UserManagementViewModel> allUsersViewModel=new List<UserManagementViewModel>();
            foreach (IdentityUser user in allUser)
            {
                IEnumerable<string> role=await userManager.GetRolesAsync(user);
                allUsersViewModel.Add(new UserManagementViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = role
                });
                
            }
            return allUsersViewModel;
        }
        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            IdentityUser? user = await this.userManager
                .FindByIdAsync(userId);

            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(string userId, string roleName)
        {
            IdentityUser? user = await userManager
                .FindByIdAsync(userId);
            

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (!alreadyInRole)
            {
                IdentityResult? result = await this.userManager
                    .AddToRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> RemoveUserRoleAsync(string userId, string roleName)
        {
            IdentityUser? user = await userManager
                .FindByIdAsync(userId);
            

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (alreadyInRole)
            {
                IdentityResult? result = await this.userManager
                    .RemoveFromRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            IdentityResult? result = await this.userManager
                .DeleteAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
