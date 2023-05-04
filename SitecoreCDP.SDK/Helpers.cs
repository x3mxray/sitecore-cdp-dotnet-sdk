using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
//using Bogus;
//using Bogus.DataSets;
//using static Bogus.DataSets.Name;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Models.Batch;


namespace SitecoreCDP.SDK
{
    public static class Helpers
    {
        public static byte[] Md5Hash(string file)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(file);
            return md5.ComputeHash(stream);
        }

        public static string CheckSum(byte[] md5Hash)
        {
            return BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
        }

        public static long FileSize(string file)
        {
            return new FileInfo(file).Length;
        }

        public static string CompressFile(string file)
        {
            var gzip = file.Replace(".json", ".gz");
            using FileStream originalFileStream = File.Open(file, FileMode.Open);
            using FileStream compressedFileStream = File.Create(gzip);
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);
            return gzip;
        }

        public static byte[] DecompressFile(byte[] gzip)
        {
            using GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress);
            const int size = 4096;
            byte[] buffer = new byte[size];
            using MemoryStream memory = new MemoryStream();
            int count = 0;
            do
            {
                count = stream.Read(buffer, 0, size);
                if (count > 0)
                {
                    memory.Write(buffer, 0, count);
                }
            }
            while (count > 0);
            return memory.ToArray();
        }

        public static void ExportToJson(string fileName, List<Batch> batches)
        {
            using var file = File.CreateText(fileName);
            foreach (var batch in batches)
            {
                file.WriteLine(JsonSerializer.Serialize(batch));
            }
        }

        //static Faker<Guest>  GuestRule = new Faker<Guest>()
        //.RuleFor(u => u.Gender, f => f.PickRandom<Gender>().ToString().ToLower())
        //.RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(Enum.Parse<Name.Gender>(ToTitleCase(u.Gender))))
        //.RuleFor(u => u.LastName, (f, u) => f.Name.LastName(Enum.Parse<Name.Gender>(ToTitleCase(u.Gender))))
        //.RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName).ToLower())
        //.RuleFor(u => u.Phone, (f, u) => f.Phone.PhoneNumber("+966#########"))
        //.RuleFor(u => u.Country, (f, u) => f.Address.CountryCode())
        //.RuleFor(u => u.State, (f, u) => f.Address.State())
        //.RuleFor(u => u.City, (f, u) => f.Address.City())
        //.RuleFor(u => u.PostCode, (f, u) => f.Address.ZipCode())
        //.RuleFor(u => u.FirstSeen, (f, u) => f.Date.Past().ToUniversalTime())
        //.RuleFor(u => u.LastSeen, (f, u) => f.Date.Recent().ToUniversalTime())
        //.RuleFor(u => u.PhoneNumbers, (f, u) => new List<string>{ u.Phone })
        //;

        //private static Faker<OrderItem> OrderItemRule = new Faker<OrderItem>()
        //    .RuleFor(u => u.CurrencyCode, (f, u) => "AED")
        //    .RuleFor(u => u.OriginalCurrencyCode, (f, u) => "AED")
        //    .RuleFor(u => u.Price, (f, u) => decimal.Parse(f.Commerce.Price()))
        //    .RuleFor(u => u.OriginalPrice, (f, u) => u.Price)
        //    .RuleFor(u => u.Quantity, (f, u) => f.Random.Number(1, 3))
        //    .RuleFor(u => u.Name, (f, u) => f.Commerce.ProductName())
        //    .RuleFor(u => u.Description, (f, u) => f.Commerce.ProductDescription())
        //    .RuleFor(u => u.ProductId, (f, u) => f.Commerce.Ean8())
        //    .RuleFor(u => u.ReferenceId, (f, u) => u.ProductId)
        //    .RuleFor(u => u.OrderedAt, (f, u) => f.Date.Recent().ToUniversalTime());

        //private static Faker<Order> OrderRule = new Faker<Order>()
        //    .RuleFor(u => u.CurrencyCode, (f, u) => "AED")
        //    .RuleFor(u => u.ReferenceId, (f, u) => f.Commerce.Ean13())
        //    .RuleFor(u => u.Channel, (f, u) => "OFFLINE")
        //    .RuleFor(u => u.PaymentType, (f, u) => "Cash")
        //    .RuleFor(u => u.PointOfSale, (f, u) => "x3mxray.demo.com")
        //    .RuleFor(u => u.Status, (f, u) => "PURCHASED")
        //    .RuleFor(u => u.OrderedAt, (f, u) => f.Date.Recent().ToUniversalTime());


        //public static List<Order> GenerateOrders(int count = 3)
        //{
        //    var orders = OrderRule.Generate(count);
        //    foreach (var order in orders)
        //    {
        //        order.OrderItems = OrderItemRule.Generate(2);
        //        order.Price = order.OrderItems.Sum(x => x.Price * x.Quantity);
        //        order.OrderedAt = order.OrderItems.Max(x => x.OrderedAt);
        //        order.Contact = GenerateGuest();
        //    }

        //    return orders;
        //}
        //public static OrderItem GenerateOrderItem()
        //{
        //    var item = OrderItemRule.Generate();
        //    return item;
        //}

        //public static Guest GenerateGuest()
        //{
        //    var guest = GuestRule.Generate();
        //    guest.Identifiers = new List<Identifier>
        //    {
        //        new()
        //        {
        //            Provider = "email",
        //            Id = guest.Email
        //        },
        //        new()
        //        {
        //            Provider = "phone",
        //            Id = guest.Phone
        //        }
        //    };
        //    guest.Extensions = new List<Extension>
        //    {
        //        new()
        //    };
        //    return guest;
        //}

        //public static List<Guest> GenerateGuests(int count=3)
        //{
        //    var guests = GuestRule.Generate(count);
        //    foreach (var guest in guests)
        //    {
        //        guest.Identifiers = new List<Identifier>
        //        {
        //            new()
        //            {
        //                Provider = "email",
        //                Id = guest.Email
        //            },
        //            new()
        //            {
        //                Provider = "phone",
        //                Id = guest.Phone
        //            }
        //        };
        //        guest.Extensions = new List<Extension>
        //        {
        //            new()
        //        };
        //    }
            
        //    return guests;
        //}

        public static string ToTitleCase(string str)
        {
            var firstword = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.Split(' ')[0].ToLower());
            str = str.Replace(str.Split(' ')[0], firstword);
            return str;
        }
    }
}
