using CSAMS.Models;
using System;
using System.IO;

namespace CSAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlFile = "../../../Data/csams_test.sql";
            if (File.Exists(sqlFile))
                Console.WriteLine("IT EXISTS!");
            Console.WriteLine("Hello World!");
        }
    }
}
