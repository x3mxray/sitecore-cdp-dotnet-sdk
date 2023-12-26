// <copyright file="Helpers.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
//using Bogus;
//using Bogus.DataSets;
//using static Bogus.DataSets.Name;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Models.Batch;


namespace SitecoreCDP.SDK
{
    public static class Helpers
    {
        static JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public static byte[] Md5Hash(byte[] file)
        {
            using var md5 = MD5.Create();
            return md5.ComputeHash(file);
        }
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

        public static long FileSize(Stream fileStream)
        {
            return fileStream.Length;
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

        public static byte[] CompressFile(byte[] file)
        {
            using (MemoryStream input = new MemoryStream(file))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    using (GZipStream compression = new GZipStream(output, CompressionMode.Compress))
                    {
                        input.CopyTo(compression);
                        return output.ToArray();
                    }
                }
            }
            
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

        public static byte[] ExportToBatchJsonFile(this List<Batch> batches, string fileName)
        {
            using (var file = File.CreateText(fileName))
            {
                foreach (var batch in batches)
                {
                    if (batch is BatchGuest guest)
                    {
                        file.WriteLine(JsonSerializer.Serialize<BatchGuest>(guest, serializerOptions));
                    }
                    else if (batch is BatchOrder order)
                    {
                        file.WriteLine(JsonSerializer.Serialize<BatchOrder>(order, serializerOptions));
                    }
                }
            }

            // var test = CompressFile(fileName);

			return File.ReadAllBytes(fileName);
        }

        public static byte[] ExportToBatchGzipFile(this List<Batch> batches, string fileName)
        {
	        using (var file = File.CreateText(fileName))
	        {
		        foreach (var batch in batches)
		        {
			        if (batch is BatchGuest guest)
			        {
				        file.WriteLine(JsonSerializer.Serialize<BatchGuest>(guest, serializerOptions));
			        }
			        else if (batch is BatchOrder order)
			        {
				        file.WriteLine(JsonSerializer.Serialize<BatchOrder>(order, serializerOptions));
			        }
		        }
	        }

	        var gzip = CompressFile(fileName);

	        return File.ReadAllBytes(gzip);
        }

		public static byte[] ExportToBatchFile(this List<Batch> batches)
        {
            using (var ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))
                {
                    foreach (var batch in batches)
                    {
                        if (batch is BatchGuest guest)
                        {
                            tw.WriteLine(JsonSerializer.Serialize<BatchGuest>(guest, serializerOptions));
                        }
                        else if (batch is BatchOrder order)
                        {
                            tw.WriteLine(JsonSerializer.Serialize<BatchOrder>(order, serializerOptions));
                        }
                    }
                    tw.Flush();
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }

        public static string ToValidJson(this List<Batch> batches)
        {
            var list = new List<dynamic>();
            foreach (var batch in batches)
            {
                if (batch is BatchGuest guest)
                {
                    list.Add((BatchGuest) guest);
                }
                else if (batch is BatchOrder order)
                {
                    list.Add((BatchOrder)order);
                }
            }
            return JsonSerializer.Serialize(list, serializerOptions);
        }

        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> items,
            CancellationToken cancellationToken = default)
        {
            var results = new List<T>();
            await foreach (var item in items.WithCancellation(cancellationToken)
                               .ConfigureAwait(false))
                results.Add(item);
            return results;
        }
    }
}
