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
    }
}
