

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
            ICollection<UserManagementViewModel> allUsersVoewModel=new List<UserManagementViewModel>();
            foreach (IdentityUser user in allUser)
            {
                IEnumerable< string> role=await userManager.GetRolesAsync(user);
                allUsersVoewModel.Add(new UserManagementViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = role
                });
                
            }
            return allUsersVoewModel;
        }
    }
}
