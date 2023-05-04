using System.Net.Http.Headers;
using System.Text.Json;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Models.Interactive;
using Guest = SitecoreCDP.SDK.Models.Interactive.Guest;
using Order = SitecoreCDP.SDK.Models.Interactive.Order;
using OrderItem = SitecoreCDP.SDK.Models.Interactive.OrderItem;

namespace SitecoreCDP.SDK.Services
{

    internal class InteractiveApiService: BaseService, IInteractiveApiService
    {
        public InteractiveApiGuestService Guests { get; }
        public InteractiveApiOrderService Orders { get; }
        public InteractiveApiOrderItemService OrderItems { get; }
        public InteractiveApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
            Guests = new InteractiveApiGuestService(cdpClientConfig);
            Orders = new InteractiveApiOrderService(cdpClientConfig);
            OrderItems = new InteractiveApiOrderItemService(cdpClientConfig);
        }
    }


    public class InteractiveApiOrderItemService : BaseService, IInteractiveApiOrderItemService
    {
        public InteractiveApiOrderItemService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public IEnumerable<Models.Interactive.OrderItem> Find(string orderRef)
        {
            var uri = new Uri(Endpoints.Interactive.OrderItem.Find(orderRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.Deserialize<FindResponse>(response);
                foreach (var order in obj.Items)
                {
                    var href = order.Href.Split("/").Last();
                    yield return Get(href);
                }
            }
        }

        public Models.Interactive.OrderItem Get(string orderRef)
        {
            var uri = new Uri(Endpoints.Interactive.OrderItem.Get(orderRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<Models.Interactive.OrderItem>(response);
            }

            throw CdpException(response);
        }
    }



    public class InteractiveApiOrderService : BaseService, IInteractiveApiOrderService
    {
        public InteractiveApiOrderService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public IEnumerable<Models.Interactive.Order> Find(string guestRef)
        {
            var uri = new Uri(Endpoints.Interactive.Order.Find(guestRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.Deserialize<FindResponse>(response);
                foreach (var order in obj.Items)
                {
                    var href = order.Href.Split("/").Last();
                    yield return Get(href);
                }
            }
        }

        public Models.Interactive.Order Get(string orderRef)
        {
            var uri = new Uri(Endpoints.Interactive.Order.Get(orderRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<Models.Interactive.Order>(response);
            }

            throw CdpException(response);
        }
    }

    

    public class InteractiveApiGuestService: BaseService, IInteractiveApiGuestService
    {
       
        public InteractiveApiGuestService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public Models.Interactive.Guest Update(string guestRef, GuestCreate guest)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Update(guestRef));
            var textContent = JsonSerializer.Serialize(guest);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PostAsync(uri, content).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<Models.Interactive.Guest>(response);
            }

            throw CdpException(response);
        }
        public Models.Interactive.Guest Create(GuestCreate guest)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Create);
            var textContent = JsonSerializer.Serialize(guest);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PostAsync(uri, content).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<Models.Interactive.Guest>(response);
            }

            throw CdpException(response);
        }

        public GuestContext Find(string email)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Find(email));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.Deserialize<FindResponse>(response);
                var href = obj.Items[0].Href.Split("/").Last();
                return GetContext(href);
            }

            throw CdpException(response);
        }

        public GuestContext GetContext(string guestRef)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.GetContext(guestRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<GuestContext>(response);
            }

            throw CdpException(response);
        }
        public Models.Interactive.Guest Get(string guestRef)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Get(guestRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
               
               return JsonSerializer.Deserialize<Models.Interactive.Guest>(response);
            }

            throw CdpException(response);
        }
    }
    
}
