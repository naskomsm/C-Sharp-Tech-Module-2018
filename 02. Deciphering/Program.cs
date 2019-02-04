using System;
using System.Collections.Generic;

namespace CodeHere2
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedString = Console.ReadLine();
            string secondInput = Console.ReadLine();
            bool isValid = false;

            for (int i = 0; i < encryptedString.Length; i++)
            {
                if ((char)encryptedString[i] >= 100 && (char)encryptedString[i] <= 122 || (char)encryptedString[i] >= 123 && (char)encryptedString[i] <= 125 || encryptedString[i] == '#')
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                string decryptedString = string.Empty;
                string[] splittedSecondInput = secondInput.Split();

                for (int i = 0; i < encryptedString.Length; i++)
                {
                    char currentChar = encryptedString[i];
                    int newCharASCII = currentChar - 3;
                    char newChar = (char)newCharASCII;
                    decryptedString += newChar.ToString();
                }

                string oldChar = splittedSecondInput[0];
                string newerChar = splittedSecondInput[1];

                string output = decryptedString.Replace(oldChar, newerChar);
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
