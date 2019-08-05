using System;
using System.Collections.Generic;

namespace _04._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerInfo = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if(input=="Season end")
                {
                    break;
                }
                string[] splittedInput = input.Split(" -> ");
                if (splittedInput[1] == "vs") // PLAYER VS PLAYER
                {
                    string firstPlayer = splittedInput[0];
                    string secondPlayer = splittedInput[2];



                }
                else // full info
                {
                    string player = splittedInput[0];
                    string position = splittedInput[1];
                    int skill = int.Parse(splittedInput[2]);

                    if (!playerInfo.ContainsKey(player))
                    {
                        playerInfo.Add(player, new Dictionary<string, int>());
                        playerInfo[player].Add(position, skill);
                    }
                    else
                    {
                        playerInfo[player].Add(position, skill);
                    }
                }
            }
        }
    }
}
