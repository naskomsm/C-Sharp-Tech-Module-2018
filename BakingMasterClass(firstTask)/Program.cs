using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testArea
{
    class Program
    {

        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double sum = 0;
            int freePackages = students / 5;

            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());


            double ceiledStudens = Math.Ceiling(students * 1.2);

            double finalPrice = priceOfApron * ceiledStudens + (priceOfEgg * 10) * students + priceOfFlour * (students - freePackages);
            sum += finalPrice;


            if (sum <= budget)
            {
                Console.WriteLine($"Items purchased for {sum:f2}$.");
            }
            else
            {
                double neededMoney = sum - budget;
                Console.WriteLine($"{neededMoney:f2}$ more needed.");
            }

        }
    }
}
