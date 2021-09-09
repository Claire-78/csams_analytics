using CSAMS.Models;
using System;
using System.Linq;
using System.IO;

namespace CSAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            Console.WriteLine(db.Assignments.FirstOrDefault().Description);
        }
    }
}
