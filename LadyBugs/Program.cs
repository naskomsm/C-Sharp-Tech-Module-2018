using System;
using System.Linq;
using System.Text.RegularExpressions;

class LargestCommonEnd
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[] bugIndex = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] initialField = new int[fieldSize]; // we create the initial(first) field
        for (int i = 0; i < fieldSize; i++)
        {
            if (bugIndex.Contains(i))
            {
                initialField[i] = 1;
            }
        } // 

        if (initialField.Length <= fieldSize)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] inputArr = input.Split();

                int startIndex = int.Parse(inputArr[0]);
                string direction = inputArr[1];
                int flylength = int.Parse(inputArr[2]);

                int endIndex = 0;
                if (startIndex >= 0 && startIndex <= fieldSize)
                {
                    if (direction == "right")
                    {
                        endIndex = startIndex + flylength;

                    }
                    else if (direction == "left")
                    {
                        endIndex = startIndex - flylength;
                    }
                }
                else if (startIndex < 0 || startIndex >= fieldSize) continue; // if input is not correct continue;
                if (initialField[startIndex] == 0) continue;

                ////////////////////////////////////////////////////////////////////////////

                initialField[startIndex] = 0;

                while (endIndex >= 0 && endIndex < fieldSize) // proverka za tova dali ima bubi sled leteneto
                {
                    if (direction == "right")
                    {
                        if (initialField[endIndex] == 0) // ako nqma buba tam..kacame
                        {
                            initialField[endIndex] = 1;
                            break;
                        }
                        else if (initialField[endIndex] == 1) // ako ima buba pak leti flylength
                        {
                            endIndex += flylength;
                        }
                    }

                    if (direction == "left")
                    {
                        if (initialField[endIndex] == 0)
                        {
                            initialField[endIndex] = 1;
                            break;
                        }
                        else if (initialField[endIndex] == 1)
                        {
                            endIndex -= flylength;
                        }
                    }

                }

            }
            Console.WriteLine(string.Join(" ", initialField));
        }


    }
}