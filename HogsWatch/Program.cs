using System;

namespace Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHomes = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());

            int presentsLeft = initialPresents;
            int returns = 0;
            int additionalPresents = 0;

            for (int currentHome = 1; currentHome <= numberOfHomes; currentHome++)
            {
                int numberOfPresents = int.Parse(Console.ReadLine());

                if (presentsLeft >= numberOfPresents)
                {
                    presentsLeft -= numberOfPresents;
                }
                else
                {
                    returns++;
                    int presentsNeeded = (initialPresents / currentHome) * (numberOfHomes - currentHome) + (numberOfPresents - presentsLeft);
                    additionalPresents += presentsNeeded;
                    presentsLeft += presentsNeeded;
                    presentsLeft -= numberOfPresents;
                }
            }

            if (returns == 0)
            {
                Console.WriteLine(presentsLeft);
            }
            else
            {
                Console.WriteLine(returns);
                Console.WriteLine(additionalPresents);
            }
        }
    }
}