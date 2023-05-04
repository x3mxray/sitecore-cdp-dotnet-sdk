using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    interface IInteractiveApiGuestService
    {
        Task<Guest> Get(string guestRef);
        Task<GuestContext> GetContext(string guestRef);
        Task<GuestContext> Find(string email);
        Task<Guest> Create(GuestCreate guest);
        Task<Guest> Update(string guestRef, GuestCreate guest);
    }
}
