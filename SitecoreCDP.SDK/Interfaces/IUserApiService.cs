using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Tenant;

namespace SitecoreCDP.SDK.Interfaces
{
    public interface IUserApiService
    {
        Task<User> Get(string userRef);
        Task<UserFindResponse> GetAll(int limit = 10, int offset = 0);
    }
}
