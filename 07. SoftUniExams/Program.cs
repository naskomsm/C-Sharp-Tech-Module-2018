using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Results = new Dictionary<string, int>();
            Dictionary<string, int> Submissions = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }
                string[] splittedInput = input.Split("-");

                if (splittedInput.Length == 3)
                {
                    string userName = splittedInput[0];
                    string language = splittedInput[1];
                    int points = int.Parse(splittedInput[2]);

                    if (!Results.ContainsKey(userName))
                    {
                        Results.Add(userName, points);
                    }
                    else
                    {
                        if (Results[userName] < points)
                        {
                            Results[userName] = points;
                        }
                    }

                    if (!Submissions.ContainsKey(language))
                    {
                        Submissions.Add(language, 1);
                    }
                    else
                    {
                        Submissions[language]++;
                    }

                }
                else // its command
                {
                    string userName = splittedInput[0];
                    string command = splittedInput[1];
                    if (command == "banned")
                    {
                        Results.Remove(userName);
                    }
                }
            }

            Results = Results.OrderBy(x => x.Key).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Submissions = Submissions.OrderByDescending(x => x.Value).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Results: ");
            foreach (var kvp in Results)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine($"Submissions: ");
            foreach (var kvp in Submissions)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}