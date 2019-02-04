using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodePlace
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeDishes = 0;
            int timeCleaning = 0;
            int timeLaundry = 0;
            int totalTime = 0;

            string dishesPattern = @"(?<=<)[a-z0-9]+(?=>)";
            string timePattern = @"(?<=\[)[A-Z0-9]+(?=\])";
            string laundryPattern = @"(?<={).+(?=})";


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "wife is happy")
                {
                    break;
                }

                Match dishesMatch = Regex.Match(input, dishesPattern);
                Match cleaningMatch = Regex.Match(input, timePattern);
                Match laundryMatch = Regex.Match(input, laundryPattern);

                string matchedString = string.Empty;
                if (dishesMatch.Success)
                {
                    matchedString = dishesMatch.ToString();
                    for (int i = 0; i < matchedString.Length; i++)
                    {
                        if (char.IsDigit(matchedString[i]))
                        {
                            int currentNumber = int.Parse(matchedString[i].ToString());
                            timeDishes += currentNumber;
                        }
                    }
                }
                else if (cleaningMatch.Success)
                {
                    matchedString = cleaningMatch.ToString();
                    for (int i = 0; i < matchedString.Length; i++)
                    {
                        if (char.IsDigit(matchedString[i]))
                        {
                            int currentNumber = int.Parse(matchedString[i].ToString());
                            timeCleaning += currentNumber;
                        }
                    }
                }
                else if (laundryMatch.Success)
                {
                    matchedString = laundryMatch.ToString();
                    for (int i = 0; i < matchedString.Length; i++)
                    {
                        if (char.IsDigit(matchedString[i]))
                        {
                            int currentNumber = int.Parse(matchedString[i].ToString());
                            timeLaundry += currentNumber;
                        }
                    }
                }
            }
            totalTime = timeDishes + timeLaundry + timeCleaning;
            Console.WriteLine($"Doing the dishes - {timeDishes} min.");
            Console.WriteLine($"Cleaning the house - {timeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {timeLaundry} min.");
            Console.WriteLine($"Total - {totalTime} min.");
        }
    }
}
