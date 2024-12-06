using FishingMania.Services.Data.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingMania.Services.Data.Interface_and_services.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserManagementViewModel>> GetAllUsersAsync();
        Task<bool> UserExistsByIdAsync(string userId);

        Task<bool> AssignUserToRoleAsync(string userId, string roleName);

        Task<bool> RemoveUserRoleAsync(string userId, string roleName);

        Task<bool> DeleteUserAsync(string userId);
    }
}
