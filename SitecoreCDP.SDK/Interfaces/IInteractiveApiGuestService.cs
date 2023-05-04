using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    interface IInteractiveApiGuestService
    {
        Guest Get(string guestRef);
        GuestContext Find(string email);
        Guest Create(GuestCreate guest);
        Guest Update(string guestRef, GuestCreate guest);
    }
}
