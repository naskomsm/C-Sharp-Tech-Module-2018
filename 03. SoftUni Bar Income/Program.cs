using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalIncome = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }

                // dont look at this :D:D:D:D:D
                int start1 = input.IndexOf('%');
                int start2 = input.IndexOf('<');
                int end2 = input.IndexOf('>');
                int start3 = input.IndexOf('|');
                int start4 = input.LastIndexOf('|') + 1;
                int end4 = input.IndexOf('$');

                string customer = input.Substring(start1, input.LastIndexOf('%') - start1).Trim('%');
                string product = input.Substring(start2, end2 - start2).Trim('<');
                int count = int.Parse(input.Substring(start3, input.LastIndexOf('|') - start3).Trim('|'));
                double price = double.Parse(input.Substring(start4, end4 - start4));

                double totalPrice = count * price;
                totalIncome += totalPrice;
                Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}