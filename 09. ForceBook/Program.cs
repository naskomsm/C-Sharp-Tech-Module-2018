using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceRegister = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }
                if (input.Contains('|'))
                {
                    string[] data = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string side = data[0];
                    string user = data[1];
                    if (!forceRegister.ContainsKey(side))
                    {
                        forceRegister.Add(side, new List<string>());
                    }
                    if (!forceRegister[side].Contains(user) && !forceRegister.Values.Any(x => x.Contains(user)))
                    {
                        forceRegister[side].Add(user);

                    }

                }
                else if (input.Contains("->"))
                {
                    string[] data = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string user = data[0];
                    string side = data[1];

                    if (!forceRegister.Any(x => x.Value.Contains(user)))
                    {
                        if (!forceRegister.ContainsKey(side))
                        {

                            forceRegister.Add(side, new List<String>());
                        }

                        forceRegister[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var s in forceRegister)
                        {
                            if (s.Value.Contains(user))
                            {
                                s.Value.Remove(user);
                            }
                        }

                        if (!forceRegister.ContainsKey(side))
                        {
                            forceRegister.Add(side, new List<string>());
                        }
                        forceRegister[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
            }

            forceRegister = forceRegister.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);


            foreach (var kvp in forceRegister)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count()}");
                foreach (var user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}