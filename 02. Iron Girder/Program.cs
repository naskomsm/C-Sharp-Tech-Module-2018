using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Iron_Girder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> storage = new Dictionary<string, int[]>(); 

            // [0] - time
            // [1] - passengers

            while (true)
            {
                string[] input = Console.ReadLine().Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);
                if(input[0]=="Slide rule")
                {
                    break;
                }

                string townName = input[0];
                string time = input[1];
                string passengersCount = input[2];

                if (time == "ambush")
                {
                    if (storage.ContainsKey(townName))
                    {
                        storage[townName][0] = 0;
                        storage[townName][1] -= int.Parse(passengersCount);
                    }
                }

                if (!storage.ContainsKey(townName) && time!="ambush")
                {
                    storage.Add(townName, new int[2]);
                    storage[townName][0] = int.Parse(time);
                    storage[townName][1] = int.Parse(passengersCount);
                }
                else if(storage.ContainsKey(townName) && time != "ambush")
                {
                    storage[townName][1] += int.Parse(passengersCount);
                    if(storage[townName][0] > int.Parse(time) || storage[townName][0] == 0)
                    {
                        storage[townName][0] = int.Parse(time);
                    }
                    
                }
            }
            storage = storage.OrderBy(x => x.Value[0]).ThenBy(x => x.Key).Where(x => x.Value[0] != 0).Where(x => x.Value[1] != 0).ToDictionary(x => x.Key, x => x.Value);
            // holy fuck

            foreach (var kvp in storage)
            {
                Console.WriteLine($"{kvp.Key} -> Time: {kvp.Value[0]} -> Passengers: {kvp.Value[1]}");
            }
        }
    }
}
