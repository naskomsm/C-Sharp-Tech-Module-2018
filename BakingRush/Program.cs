using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace bakingRush
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split('|').ToList();
            double Initialenergy = 100;
            double Initialcoins = 100;
            bool isCompleted = true;

            for (int i = 0; i < list.Count; i++)
            {
                string[] split = list[i].Split('-');
                string first = split[0]; // eggs  
                string second = split[1]; // 100

                if (list[i].Contains("rest"))
                {
                    int energy = int.Parse(second);
                    if (Initialenergy + energy > 100)
                    {
                        Console.WriteLine($"You gained 0 energy.");
                    }
                    else
                    {
                        Initialenergy += energy;
                        Console.WriteLine($"You gained {energy} energy.");
                    }
                    Console.WriteLine($"Current energy: {Initialenergy}.");

                }


                else if (list[i].Contains("order"))
                {
                    int coins = int.Parse(second);

                    if (Initialenergy - 30 >= 0)
                    {
                        Initialenergy -= 30;
                        Initialcoins += coins;
                        Console.WriteLine($"You earned {coins} coins.");
                    }

                    else
                    {
                        Initialenergy += 50;
                        Console.WriteLine($"You had to rest!");
                    }


                }

                else
                {
                    string product = first;
                    int price = int.Parse(second);
                    Initialcoins -= price;
                    if (Initialcoins > 0)
                    {
                        Console.WriteLine($"You bought {product}.");
                    }
                    else if(Initialcoins<=0)
                    {
                        Console.WriteLine($"Closed! Cannot afford {product}.");
                        isCompleted = false;
                        break;
                    }
                }

            }
            if (isCompleted)
            {
                Console.WriteLine($"Day completed!");
                Console.WriteLine($"Coins: {Initialcoins}");
                Console.WriteLine($"Energy: {Initialenergy}");
            }



        }
    }
}
