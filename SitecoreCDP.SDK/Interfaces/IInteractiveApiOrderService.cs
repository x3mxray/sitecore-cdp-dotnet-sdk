using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    interface IInteractiveApiOrderService
    {
        IEnumerable<Order> Find(string guestRef);
    }
}
