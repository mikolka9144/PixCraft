using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToBase64String(File.ReadAllBytes("PixBlocks Compatiblity layer.dll")));
            Console.WriteLine(Convert.ToBase64String(File.ReadAllBytes("PixCraft.dll")));
            Console.WriteLine(Convert.ToBase64String(File.ReadAllBytes("Integration.dll")));
            Console.ReadKey();
        }
    }
}