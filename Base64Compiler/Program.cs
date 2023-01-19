// See https://aka.ms/new-console-template for more information
using System;
Console.Write("bin = \"");
Console.Write(Convert.ToBase64String(File.ReadAllBytes("./PixBlocks Compatiblity layer/bin/Debug/PixBlocks Compatiblity layer.dll")));
Console.Write("\"");
Console.Read();