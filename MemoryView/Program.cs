using System;
using System.Collections.Generic;
using System.Linq;

namespace Memory_View
{
    class Program
    {
        static void Main(string[] args)
        { //start time 9:38 - solve 90% 22:12 (34min)

            string input = Console.ReadLine();

            List<int> list = new List<int>();
            while (input != "Visual Studio crash")
            {

                int[] line = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                list.AddRange(line);
                input = Console.ReadLine();
            }


            List<string> result = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                int length = 0;
                if (list[i] == 32763)
                {
                    length = list[i + 2];
                    string name = "";
                    for (int j = i + 4; j < i + 4 + length; j++)
                    {
                        char current = (char)list[j];
                        name += current;
                    }
                    result.Add(name);

                }
            }
            foreach (var thing in result)
            {
                Console.WriteLine(thing);
            }

        }
    }
}