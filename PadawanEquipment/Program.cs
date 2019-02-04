using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());

            double priceOflightsabers = double.Parse(Console.ReadLine());
            double priceOfrobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double tenPercentMoreLightSabers = countOfStudents + (countOfStudents * 0.1);
            tenPercentMoreLightSabers = Math.Ceiling(tenPercentMoreLightSabers);
            double freeBelt = countOfStudents / 6;

            double formula = priceOflightsabers * tenPercentMoreLightSabers + priceOfrobes * countOfStudents + priceOfBelts * (countOfStudents - freeBelt);
            if (formula <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {formula:f2}lv.");
            }
            else
            {
                double neededMoney = formula - amountOfMoney;
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }
        }
    }
}
