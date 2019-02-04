using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;

            if (input.Length != 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string currentPart = input[i];
                    int lengthToSubString = currentPart.Length - 2;
                    string numbersPart = currentPart.Substring(1, lengthToSubString);

                    char charBeforeNumber = currentPart[0];
                    char charAfterNumber = currentPart[currentPart.Length - 1];

                    int letterPositionInAlphabetBeforeNumber = (int)charBeforeNumber % 32;
                    int letterPositionInAlphabetAfterNumber = (int)charAfterNumber % 32;

                    double operation = 0;
                    double operation2 = 0;

                    if (char.IsUpper(charBeforeNumber))
                    {
                        operation = double.Parse(numbersPart) / letterPositionInAlphabetBeforeNumber;
                    }
                    else if (char.IsLower(charBeforeNumber))
                    {
                        operation = double.Parse(numbersPart) * letterPositionInAlphabetBeforeNumber;
                    }

                    if (char.IsUpper(charAfterNumber))
                    {
                        operation2 = operation - letterPositionInAlphabetAfterNumber;
                        totalSum += operation2;
                    }
                    else if (char.IsLower(charAfterNumber))
                    {
                        operation2 = operation + letterPositionInAlphabetAfterNumber;
                        totalSum += operation2;
                    }
                }
                Console.WriteLine($"{totalSum:f2}");
            }
        }
    }
}
