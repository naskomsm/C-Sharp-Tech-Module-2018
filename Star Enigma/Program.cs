using System;
using System.Collections.Generic;
using System.Linq;

namespace CodePlace
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int attackedPlanets = 0;
            int destroyedPlanets = 0;
            Dictionary<string, int> attackedPlanetsDict = new Dictionary<string, int>();
            Dictionary<string, int> destroyedPlanetsDict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int charCount = 0;

                string remakedInput = string.Empty;

                string planetName = string.Empty;
                string population = string.Empty;
                string attackSymbol = string.Empty;
                string soldierCount = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    char currentChar = input[j];
                    if (currentChar == 'S' || currentChar == 'T' || currentChar == 'A' || currentChar == 'R' || currentChar == 's' || currentChar == 't' || currentChar == 'a' || currentChar == 'r')
                    {
                        charCount++;
                    }
                } // to count the givenChars
                for (int h = 0; h < input.Length; h++)
                {
                    int Char = input[h] - charCount;
                    char newChar = (char)Char;
                    remakedInput += newChar;
                } // to get the remakedInput

                // Planet Name
                int startIndexOfPlanetName = remakedInput.IndexOf('@');
                int endIndexOfPlanetName = remakedInput.IndexOf(':');
                for (int p = startIndexOfPlanetName + 1; p < endIndexOfPlanetName; p++)
                {
                    int charOfCurrentSymbol = remakedInput[p];
                    if (charOfCurrentSymbol >= 'A' && charOfCurrentSymbol <= 'Z' || charOfCurrentSymbol >= 'a' && charOfCurrentSymbol <= 'z')
                    {
                        planetName += remakedInput[p];
                    }
                }

                // Population
                int startIndexOfPopulation = remakedInput.IndexOf(':');
                int endIndexOfPopulation = remakedInput.IndexOf('!');
                for (int q = startIndexOfPopulation + 1; q < endIndexOfPopulation; q++)
                {
                    population += remakedInput[q];
                }

                // attackSymbol
                int startIndexOfAorD = remakedInput.IndexOf('!');
                int endIndexOfAorD = remakedInput.LastIndexOf('!');
                for (int r = startIndexOfAorD + 1; r < endIndexOfAorD; r++)
                {
                    attackSymbol += remakedInput[r];
                }

                // soldierCount
                if (remakedInput.Contains("->"))
                {
                    int startIndexOfSoldierCount = remakedInput.IndexOf("->");
                    for (int s = startIndexOfSoldierCount; s < remakedInput.Length; s++)
                    {
                        soldierCount += remakedInput[s];
                    }
                }


                if (attackSymbol == "A" && soldierCount != String.Empty)
                {
                    attackedPlanets++;
                    attackedPlanetsDict.Add(planetName, int.Parse(population));

                }
                else if (attackSymbol == "D" && soldierCount != String.Empty)
                {
                    destroyedPlanets++;
                    destroyedPlanetsDict.Add(planetName, int.Parse(population));
                }
            }

            attackedPlanetsDict = attackedPlanetsDict.OrderBy(x => x.Key).OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"Attacked planets: {attackedPlanets}");
            foreach (var kvp in attackedPlanetsDict)
            {
                Console.WriteLine($"-> {kvp.Key}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets}");
            foreach (var kvp in destroyedPlanetsDict)
            {
                Console.WriteLine($"-> {kvp.Key}");
            }
        }
    }
}
