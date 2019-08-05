using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodePlace
{
    class Program
    {
        static void Main(string[] args)
        {
            // REGEX SOLUTION 80/100
            string[] input = Console.ReadLine().Split("|");
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string firstPartPattern = @"(?<=[#$*&%])[A-Z]+(?=[#$*&%])";
            Match firstMatch = Regex.Match(firstPart, firstPartPattern);
            string letters = firstMatch.Value;

            for (int i = 0; i < letters.Length; i++)
            {
                char currentLetter = letters[i];
                int asciiCode = currentLetter;

                string secondPartPattern = $@"{asciiCode}:(?<length>[0-9][0-9])";
                Match secondMatch = Regex.Match(secondPart, secondPartPattern);
                string temp = secondMatch.Value;
                string[] tempArray = temp.Split(":");
                int length = int.Parse(tempArray[1].Trim('0'));

                string thirdPartPattern = $@"(?<=\s|^){currentLetter}[^\s]{{{length}}}(?=\s|$)";
                Match thirdMatch = Regex.Match(thirdPart, thirdPartPattern);
                string word = thirdMatch.ToString();

                Console.WriteLine(word);
            }



            // STRING PROCCESING SOLUTON 80/100

            //string input = Console.ReadLine();
            //string[] splittedInput = input.Split("|");

            //List<string> printedWords = new List<string>();
            //List<string> capitalLetters = new List<string>();

            //// firstPart
            //string firstPart = splittedInput[0];
            //for (int i = 0; i < firstPart.Length; i++)
            //{
            //    if (firstPart[i] == '#' || firstPart[i] == '$' || firstPart[i] == '%' || firstPart[i] == '*' || firstPart[i] == '&')
            //    {
            //        int count = firstPart.Count(c => c == firstPart[i]);
            //        if (count == 2)
            //        {
            //            string symbol = firstPart[i].ToString();
            //            int startIndex = firstPart.IndexOf(symbol);
            //            int endIndex = firstPart.LastIndexOf(symbol);
            //            string capitalLettersString = firstPart.Substring(startIndex, endIndex - startIndex).Trim(char.Parse(symbol));
            //            for (int h = 0; h < capitalLettersString.Length; h++)
            //            {
            //                if (capitalLettersString[h] >= 65 && capitalLettersString[h] <= 90)
            //                {
            //                    capitalLetters.Add(capitalLettersString[h].ToString());
            //                }
            //            }
            //            break;
            //        }
            //    }
            //}


            //// secondPart
            //string secondPart = splittedInput[1];

            //string asciiCode = string.Empty;
            //string lenght = string.Empty;

            //for (int i = 0; i < secondPart.Length; i++)
            //{
            //    if (i <= secondPart.Length - 4)
            //    {
            //        if (char.IsNumber(secondPart[i]) && char.IsNumber(secondPart[i + 1]) && secondPart[i + 2] == ':' && char.IsNumber(secondPart[i + 3]) && char.IsNumber(secondPart[i + 4]))
            //        {
            //            string combinedStringToCheck = secondPart[i].ToString();
            //            combinedStringToCheck += secondPart[i + 1].ToString();
            //            if (int.Parse(combinedStringToCheck) >= 65 && int.Parse(combinedStringToCheck) <= 90)
            //            {
            //                asciiCode = combinedStringToCheck;
            //                lenght = secondPart[i + 3].ToString();
            //                lenght += secondPart[i + 4];

            //                int integetAsciiCode = int.Parse(asciiCode);
            //                char firstLetter = Convert.ToChar(integetAsciiCode);

            //                // thirdPart
            //                string thirdPart = splittedInput[2];
            //                string[] splittedThirdPart = thirdPart.Split(" ");
            //                for (int k = 0; k < splittedThirdPart.Length; k++)
            //                {
            //                    int integerLength = 0;
            //                    if (lenght.Contains('0'))
            //                    {
            //                        string lengthToConvertToString = lenght.Trim('0');
            //                        integerLength = int.Parse(lengthToConvertToString) + 1;
            //                    }
            //                    else
            //                    {
            //                        integerLength = int.Parse(lenght) + 1;
            //                    }


            //                    if (splittedThirdPart[k].Contains(firstLetter) && splittedThirdPart[k].Length == integerLength && !printedWords.Contains(splittedThirdPart[k]))
            //                    {
            //                        printedWords.Add(splittedThirdPart[k]);
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //// print here
            //for (int i = 0; i < capitalLetters.Count; i++)
            //{
            //    string letterForTheWord = capitalLetters[i];
            //    for (int g = 0; g < printedWords.Count; g++)
            //    {
            //        string WordToPrint = printedWords[g];
            //        if (WordToPrint[0] == char.Parse(letterForTheWord))
            //        {
            //            Console.WriteLine(WordToPrint);
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //}
        }
    }
}
