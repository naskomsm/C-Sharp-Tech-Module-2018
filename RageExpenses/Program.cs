using System;
using System.Linq;
using System.Collections.Generic;
namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double lostGames = double.Parse(Console.ReadLine());

            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double trashedHeadset = 0;
            double trashedMouse = 0;
            double trashedKeyBoard = 0;
            double trashedDisplay = 0;
            double displayCount = 0;

            double sum = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0) // checked 
                {
                    trashedHeadset++;
                }
                if (i % 3 == 0) // checked 
                {
                    trashedMouse++;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashedKeyBoard++;
                    if (trashedKeyBoard % 2 == 0)
                    {
                        displayCount = 1;
                    }
                }
                if (trashedKeyBoard % 2 == 0 && displayCount == 1)
                {
                    trashedDisplay++;
                    displayCount = 0;
                }


            }
            headsetPrice = trashedHeadset * headsetPrice;
            mousePrice = trashedMouse * mousePrice;
            keyboardPrice = trashedKeyBoard * keyboardPrice;
            displayPrice = trashedDisplay * displayPrice;
            sum = headsetPrice + mousePrice + keyboardPrice + displayPrice;

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");

        }
    }
}