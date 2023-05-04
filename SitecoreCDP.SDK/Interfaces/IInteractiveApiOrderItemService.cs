using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    interface IInteractiveApiOrderItemService
    {
        Task<OrderItem> Get(string orderRef);
        IAsyncEnumerable<OrderItem> Find(string orderRef);
    }
}
