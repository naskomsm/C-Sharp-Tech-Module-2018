using System;
using System.Collections.Generic;

namespace _03._Tseam_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gamesInstalled = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Play!")
                {
                    break;
                }
                string[] splittedInput = input.Split();
                if (splittedInput.Length == 3) // add the default games to the list
                {
                    for (int i = 0; i < splittedInput.Length; i++)
                    {
                        gamesInstalled.Add(splittedInput[i]);
                    }
                }
                else if(splittedInput.Length == 2)
                {
                    string command = splittedInput[0];
                    string game = splittedInput[1];
                    switch (command)
                    {
                        case "Install":
                            gamesInstalled.Add(game);
                            break;
                        case "Uninstall":
                            if (gamesInstalled.Contains(game))
                            {
                                gamesInstalled.Remove(game);
                            }
                            break;
                        case "Update":
                            if (gamesInstalled.Contains(game))
                            {
                                gamesInstalled.Remove(game);
                                gamesInstalled.Add(game);
                            }
                            break;
                        case "Expansion":
                            string[] splittedGameName = game.Split('-');
                            string gameName = splittedGameName[0]; // CS
                            if (gamesInstalled.Contains(gameName))
                            {
                                string expansion = splittedGameName[1]; // GO
                                int indexOfGameName = gamesInstalled.IndexOf(gameName);
                                game = gameName + ":" + expansion;
                                if (indexOfGameName == gamesInstalled.Count-1)
                                {
                                    gamesInstalled.Add(game);
                                }
                                else
                                {
                                    gamesInstalled.Insert(indexOfGameName + 1, game);
                                }
                            }
                            break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ",gamesInstalled));
        }
    }
}
