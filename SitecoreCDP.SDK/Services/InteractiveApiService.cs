// <copyright file="InteractiveApiService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.Interactive;
using Guest = SitecoreCDP.SDK.Models.Interactive.Guest;
using Order = SitecoreCDP.SDK.Models.Interactive.Order;
using OrderItem = SitecoreCDP.SDK.Models.Interactive.OrderItem;

namespace SitecoreCDP.SDK.Services
{

    internal class InteractiveApiService : BaseService, IInteractiveApiService
    {
        public InteractiveApiGuestService Guests { get; }
        public InteractiveApiGuestExtensionsService GuestExtensions { get; }
        public InteractiveApiOrderService Orders { get; }
        public InteractiveApiOrderItemService OrderItems { get; }
        public InteractiveApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
            Guests = new InteractiveApiGuestService(cdpClientConfig);
            GuestExtensions = new InteractiveApiGuestExtensionsService(cdpClientConfig);
            Orders = new InteractiveApiOrderService(cdpClientConfig);
            OrderItems = new InteractiveApiOrderItemService(cdpClientConfig);
        }
    }


    public class InteractiveApiOrderItemService : BaseService, IInteractiveApiOrderItemService
    {
        public InteractiveApiOrderItemService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async IAsyncEnumerable<OrderItem> Find(string orderRef)
        {
            var uri = new Uri(Endpoints.Interactive.OrderItem.Find(orderRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.Deserialize<FindResponse>(response);
                foreach (var order in obj.Items)
                {
                    var href = order.Href.Split('/').Last();
                    yield return await Get(href);
                }
            }
        }

        public async Task<OrderItem> Get(string orderItemRef)
        {
            var uri = new Uri(Endpoints.Interactive.OrderItem.Get(orderItemRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<OrderItem>(result);
        }

        public async Task<OrderItem> Delete(string orderItemRef)
        {
            var uri = new Uri(Endpoints.Interactive.OrderItem.Delete(orderItemRef));
            var result = await _httpClient.DeleteAsync(uri);
            return await GetCdpResponse<OrderItem>(result);
        }

        public async Task<OrderItem> Update(string orderItemRef, OrderItem item)
        {
            var uri = new Uri(Endpoints.Interactive.OrderItem.Update(orderItemRef));
            var textContent = JsonSerializer.Serialize(item);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<OrderItem>(result);
        }
    }



    public class InteractiveApiOrderService : BaseService, IInteractiveApiOrderService
    {
        public InteractiveApiOrderService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async IAsyncEnumerable<Order> Find(string guestRef)
        {
            var uri = new Uri(Endpoints.Interactive.Order.Find(guestRef));
            var result = await _httpClient.GetAsync(uri);
            var response = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.Deserialize<FindResponse>(response);
                foreach (var order in obj.Items)
                {
                    var href = order.Href.Split('/').Last();
                    yield return await Get(href);
                }
            }
        }

        public async Task<Order> Get(string orderRef)
        {
            var uri = new Uri(Endpoints.Interactive.Order.Get(orderRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<Order>(result);
        }
    }



    public class InteractiveApiGuestService : BaseService, IInteractiveApiGuestService
    {

        public InteractiveApiGuestService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async Task<Guest> Update(string guestRef, GuestCreate guest)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Update(guestRef));
            var textContent = JsonSerializer.Serialize(guest);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<Guest>(result);
        }

        public async Task<Guest> Create(GuestCreate guest)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Create);
            var textContent = JsonSerializer.Serialize(guest);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<Guest>(result);
        }

        public async IAsyncEnumerable<GuestContext> FindByParameter(GuestParameter parameter, string value)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.FindByParameter(parameter, value));
            var result = await _httpClient.GetAsync(uri);
            var response = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
                throw CdpException(response);

            var obj = JsonSerializer.Deserialize<FindResponse>(response);

            foreach (var order in obj.Items)
            {
                var href = order.Href.Split('/').Last();
                yield return await GetContext(href);
            }
        }

        public async Task<GuestContext> FindFirstByParameter(GuestParameter parameter, string value)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.FindByParameter(parameter, value));
            var result = await _httpClient.GetAsync(uri);
            var response = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
                throw CdpException(response);

            var obj = JsonSerializer.Deserialize<FindResponse>(response);
            if (obj== null || !obj.Items.Any())
                return null;

            var href = obj.Items[0].Href.Split('/').Last();
            return await GetContext(href);
        }

        public async Task<GuestContext> FindByIdentifier(string identityProvider, string identityValue)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.FindByIdentifier(identityProvider, identityValue));
            var result = await _httpClient.GetAsync(uri);
            var response = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
                throw CdpException(response);

            var obj = JsonSerializer.Deserialize<FindResponse>(response);
            if (obj == null || !obj.Items.Any())
                return null;

            var href = obj.Items[0].Href.Split('/').Last();
            return await GetContext(href);
        }

        public async Task<GuestContext> GetContext(string guestRef)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.GetContext(guestRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<GuestContext>(result);
        }
        public async Task<Guest> Get(string guestRef)
        {
            var uri = new Uri(Endpoints.Interactive.Guest.Get(guestRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<Guest>(result);
        }
    }

}
