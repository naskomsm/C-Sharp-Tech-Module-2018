using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class Program
    {
        public static void listManipulation(List<int> numbers, int removedIndex)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (removedIndex >= numbers[i])
                {
                    numbers[i] += removedIndex;
                }
                else
                {
                    numbers[i] -= removedIndex;
                }
            }
        }
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedIndex = 0;

                if (index >= 0 && index < numbers.Count)
                {
                    removedIndex = numbers[index];
                    numbers.RemoveAt(index);
                    sum += removedIndex;
                }

                else if (index > numbers.Count - 1)
                {
                    removedIndex = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    int firstIndex = numbers[0];
                    numbers.Add(firstIndex);
                    sum += removedIndex;
                }
                else if (index < 0)
                {
                    removedIndex = numbers[0];
                    numbers.RemoveAt(0);
                    int lastIndex = numbers[numbers.Count - 1];
                    numbers.Add(lastIndex);
                    sum += removedIndex;

                }

                listManipulation(numbers, removedIndex);
            }
            Console.WriteLine(sum);
        }
    }
}
