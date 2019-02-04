using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {

            int wingFlaps = int.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            int indurance = int.Parse(Console.ReadLine());

            double first = (wingFlaps / 1000) * distance;

            double second = wingFlaps / 100;
            double rest = (wingFlaps / indurance) * 5;
            double finalRest = second + rest;

            Console.WriteLine($"{first:f2}m.");
            Console.WriteLine($"{finalRest}s.");
        }
    }
}