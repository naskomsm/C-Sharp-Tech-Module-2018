using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            double bestQuality = double.MinValue;
            double bestAverageQuality = 0;
            double fewestElements = 0;
            List<int> bestOutput = new List<int>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Bake It!")
                {
                    break;
                }
                List<int> input = command.Split('#').Select(int.Parse).ToList();
                double quality = input.Sum();
                double averageQuality = input.Average();
                double currentElements = input.Count();
                if (quality > bestQuality)
                {
                    bestQuality = quality;
                    bestAverageQuality = averageQuality;
                    fewestElements = currentElements;
                    bestOutput = input;
                }
                else if (quality == bestQuality)
                {
                    if (averageQuality > bestAverageQuality)
                    {
                        bestAverageQuality = averageQuality;
                        bestOutput = input;
                    }
                    else if (averageQuality == bestAverageQuality)
                    {
                        if (currentElements < fewestElements)
                        {
                            fewestElements = currentElements;
                            bestOutput = input;
                        }
                    }
                }
            }
            Console.WriteLine($"Best Batch quality: {bestQuality}");
            Console.WriteLine(string.Join(" ", bestOutput));
        }
    }
}