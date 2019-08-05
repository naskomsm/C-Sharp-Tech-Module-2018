using System;
using System.Text.RegularExpressions;

namespace _01._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            // REGEX 80/100
            double totalSum = 0;
            while (true)
            {
                string namePattern = @"(?<=%)[A-Z][a-z]+(?=%)";
                string productPattern = @"(?<=<)[A-z]+(?=>)";
                string countPattern = @"\|\d+\|";
                string pricePattern = @"[+-]?(?:\d+\.?\d*|\d*\.\d+)\$";

                string input = Console.ReadLine();

                if(input=="end of shift")
                {
                    break;
                }
                
                Match nameMatch = Regex.Match(input, namePattern);
                Match productMatch = Regex.Match(input, productPattern);
                Match countMatch = Regex.Match(input, countPattern);
                Match priceMatch = Regex.Match(input, pricePattern);

                if(nameMatch.Success && productMatch.Success && countMatch.Success && priceMatch.Success)
                {
                    string name = nameMatch.ToString();
                    string product = productMatch.ToString();
                    string count = countMatch.ToString().Trim('|');
                    string price = priceMatch.ToString().Trim('$');

                    double totalPrice = int.Parse(count) * double.Parse(price);
                    totalSum += totalPrice;
                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalSum:f2}");

            // STRING PROCCESING 80/100 :/
            //double totalIncome = 0;
            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "end of shift")
            //    {
            //        break;
            //    }

            //    // dont look at this :D:D:D:D:D
            //    int start1 = input.IndexOf('%');
            //    int start2 = input.IndexOf('<');
            //    int end2 = input.IndexOf('>');
            //    int start3 = input.IndexOf('|');
            //    int start4 = input.LastIndexOf('|') + 1;
            //    int end4 = input.IndexOf('$');

            //    string customer = input.Substring(start1, input.LastIndexOf('%') - start1).Trim('%');
            //    string product = input.Substring(start2, end2 - start2).Trim('<');
            //    int count = int.Parse(input.Substring(start3, input.LastIndexOf('|') - start3).Trim('|'));
            //    double price = double.Parse(input.Substring(start4, end4 - start4));

            //    double totalPrice = count * price;
            //    totalIncome += totalPrice;
            //    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
            //}
            //Console.WriteLine($"Total income: {totalIncome:f2}");

        }
    }
}
