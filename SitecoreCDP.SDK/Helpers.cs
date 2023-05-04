﻿// <copyright file="Helpers.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
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
                if (batch is BatchGuest guest)
                {
                    file.WriteLine(JsonSerializer.Serialize<BatchGuest>(guest));
                }
                else if (batch is BatchOrder order)
                {
                    file.WriteLine(JsonSerializer.Serialize<BatchOrder>(order));
                }
            }
        }
    }
}
