namespace P01_Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string allWords = Console.ReadLine();
            string wordsToPrint = Console.ReadLine();

            string[] allWordsSplitted = allWords
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            var wordsMeaning = new Dictionary<string, List<string>>();

            for (int i = 0; i < allWordsSplitted.Length; i++)
            {
                string[] currentWordAndDefinition = allWordsSplitted[i]
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string currentWord = currentWordAndDefinition[0];
                string currentDefinition = currentWordAndDefinition[1];

                if (!wordsMeaning.ContainsKey(currentWord))
                {
                    wordsMeaning[currentWord] = new List<string>();
                }

                wordsMeaning[currentWord].Add(currentDefinition);
            }

            string[] wordsToPrintSplitted = wordsToPrint
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < wordsToPrintSplitted.Length; i++)
            {
                string currentWordToPrint = wordsToPrintSplitted[i];

                if (wordsMeaning.ContainsKey(currentWordToPrint))
                {
                    Console.WriteLine(currentWordToPrint);
                    Console.WriteLine($" -{string.Join($"{Environment.NewLine} -", wordsMeaning[currentWordToPrint].OrderByDescending(x => x.Length))}");
                }
            }

            string command = Console.ReadLine();

            wordsMeaning = wordsMeaning.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            if (command == "List")
            {
                Console.WriteLine(string.Join(' ', wordsMeaning.Keys));
            }
        }
    }
}