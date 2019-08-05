using System;
using System.Collections.Generic;

namespace _09._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            // repeat method
            int timeToRepeat = 0;
            string stringToRepeat = string.Empty;

            // output
            string output = string.Empty;
            List<string> uniqueSymbolsUsed = new List<string>();
            int uniqueSymbolsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    stringToRepeat += input[i];
                }
                else if (char.IsDigit(input[i]))
                {
                    string symbol = string.Empty;
                    if (i < input.Length - 1)
                    {
                        if (char.IsDigit(input[i + 1]))
                        {
                            symbol += input[i];
                            symbol += input[i + 1];
                        }
                        else
                        {
                            symbol += input[i];
                        }
                    }
                    else
                    {
                        symbol += input[i];
                    }

                    timeToRepeat = int.Parse(symbol);
                    for (int j = 0; j < timeToRepeat; j++)
                    {
                        output += stringToRepeat;
                    }
                    stringToRepeat = string.Empty;
                }
            }
            for (int i = 0; i < output.Length; i++) // its working
            {
                if (!uniqueSymbolsUsed.Contains(output[i].ToString()))
                {
                    uniqueSymbolsUsed.Add(output[i].ToString());
                    uniqueSymbolsCount++;
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine(output);


            // RegEx решение 70/100

            //string input = Console.ReadLine();
            //string pattern = @"(([^\d]+)(\d+))";
            //int count = 0;

            //Regex regex = new Regex(pattern);
            //MatchCollection matches = regex.Matches(input);
            //StringBuilder output = new StringBuilder();

            //foreach (Match match in matches)
            //{
            //    string message = match.Groups[2].Value;
            //    int repeats = int.Parse(match.Groups[3].Value);

            //    for (int i = 0; i < repeats; i++)
            //    {
            //        output.Append(message.ToUpper());
            //    }
            //}

            //count = output.ToString().Distinct().Count();

            //Console.WriteLine($"Unique symbols used: {count}");
            //Console.WriteLine(output);
        }
    }
}
