using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    interface IInteractiveApiOrderService
    {
        IAsyncEnumerable<Order> Find(string guestRef);
        Task<Order> Get(string orderRef);
    }
}
