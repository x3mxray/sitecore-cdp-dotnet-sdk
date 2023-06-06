using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Tenant;

namespace SitecoreCDP.SDK.Interfaces
{
    public interface IConnectionsApiService
    {
        Task<Connection> Get(string connectionRef);
        Task<Connection> Create(Connection connection);
        Task<Connection> Update(Connection connection);
    }
}
