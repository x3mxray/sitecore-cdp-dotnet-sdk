using SitecoreCDP.SDK.Services;

namespace SitecoreCDP.SDK.Interfaces
{
    public interface IInteractiveApiService
    {
        public InteractiveApiGuestService Guests { get; }
        public InteractiveApiOrderService Orders { get; }
        public InteractiveApiOrderItemService OrderItems { get; }
    }
}
