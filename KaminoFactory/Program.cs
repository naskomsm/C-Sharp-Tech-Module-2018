using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int DNALength = int.Parse(Console.ReadLine());

        int length = 0;
        int sum = 0;
        int startIndex = -1;
        int row = 0;
        int currentRow = 1;

        int[] DNA = new int[DNALength];

        while (true)
        {
            string line = Console.ReadLine();

            if (line == "Clone them!")
            {
                break;
            }
            int[] currentDNA = line.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int currentSum = 0;

            for (int i = 0; i < currentDNA.Length; i++)
            {
                if (currentDNA[i] == 1)
                {
                    currentSum++;
                }
            }

            int currentStartIndex = -1;
            int currentLength = 0;
            bool isFound = false;

            if (currentRow==1)
            {
                DNA = currentDNA;
                row = currentRow;
                sum = currentSum;
            }

            if (currentRow == 1)
            {
                DNA = currentDNA;
                row = currentRow;
                sum = currentSum;
            }

            for (int i = 0; i < currentDNA.Length; i++)
            {
                if (currentDNA[i] == 1)
                {
                    if (!isFound)
                    {
                        currentStartIndex = i;
                    }
                    currentLength++;

                    if (currentLength > length)
                    {
                        length = currentLength;
                        startIndex = currentStartIndex;
                        sum = currentSum;
                        row = currentRow;
                        DNA = currentDNA;
                    }
                    else if (currentLength == length)
                    {
                        if (currentStartIndex < startIndex)
                        {
                            length = currentLength;
                            startIndex = currentStartIndex;
                            sum = currentSum;
                            row = currentRow;
                            DNA = currentDNA;
                        }
                        else if (currentSum > sum)
                        {
                            length = currentLength;
                            startIndex = currentStartIndex;
                            sum = currentSum;
                            row = currentRow;
                            DNA = currentDNA;
                        }
                    }
                }
                else
                {
                    currentStartIndex = -1;
                    currentLength = 0;
                    isFound = false;
                }
            }
            currentRow++;
        }
        Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
        Console.WriteLine(string.Join(" ",DNA));
    }
}