using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    interface IInteractiveApiOrderItemService
    {
        IEnumerable<OrderItem> Find(string orderRef);
    }
}
