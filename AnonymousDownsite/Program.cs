using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWebsitesDown = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal totalLoss = 0m;

            for (int i = 0; i < numberOfWebsitesDown; i++)
            {
                string command = Console.ReadLine();

                string[] splitCommand = command.Split();

                string siteName = splitCommand[0];
                decimal siteVisits = decimal.Parse(splitCommand[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(splitCommand[2]);

                // formula = siteVisits * siteCommercialPricePerVisit
                decimal siteLoss = siteVisits * siteCommercialPricePerVisit;
                totalLoss += siteLoss;
                Console.WriteLine(siteName);
            }
            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {Math.Pow(securityKey, numberOfWebsitesDown)}");
        }
    }
}
