using System;
using System.Linq;
using System.Collections.Generic;
namespace GrainsofSand
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> line = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Mort")
                {
                    break;
                }

                string[] splitCommand = command.Split();
                string operation = splitCommand[0];
                int value = int.Parse(splitCommand[1]);

                if (operation == "Add")
                {
                    line.Add(value);
                }
                else if (operation == "Remove")
                {
                    // you have to remove the first element in the sequence with value equal to {value}. 
                    // If there is no such element you have 
                    // to check if {value} is a valid index and remove the element at that index. 
                    // Else you should ignore that command. 

                    if (line.Contains(value))
                    {
                        line.Remove(value);
                    }
                    else if (!line.Contains(value))
                    {
                        if (value <= line.Count)
                        {
                            line.RemoveAt(value);
                        }
                    }
                    else
                    {

                    }



                }
                else if (operation == "Replace")
                {
                    // "Replace {value} {replacement}" you have to find the first occurrence of the element equal to { value}
                    // and replace its value with the { replacement}. If element equal to { value}
                    // doesn’t exists in the sequence you have to ignore this command.

                    int replacement = int.Parse(splitCommand[2]);
                    if (line.Contains(value))
                    {
                        int indexOfValue = line.IndexOf(value);
                        line.RemoveAt(indexOfValue);
                        line.Insert(indexOfValue, replacement);
                    }
                    else
                    {

                    }

                } // moje da grumne
                else if (operation == "Increase")
                {
                    // "Increase {value}" you have to find the first element with value 
                    // not less than {value} and increase the value of all elements in the 
                    // sequence with its value. If no such element exists in the sequence, 
                    // you have to take the last element from the sequence and then increase 
                    // the value of all elements in the sequence with its value.
                    bool isAnumberBiggetThanValue = false;
                    for (int i = 0; i < line.Count; i++)
                    {
                        if (line[i] >= value)
                        {
                            isAnumberBiggetThanValue = true;
                            for (int j = 0; j < line.Count; j++)
                            {
                                line[j] += value;
                            } // uvelichava vsichki elementi s Value
                            break;
                        }
                    }

                    if (isAnumberBiggetThanValue == false)
                    {
                        int lastElement = line[line.Count - 1];
                        for (int l = 0; l < line.Count; l++)
                        {
                            line[l] += lastElement;
                        }
                    }

                }
                else if (operation == "Collapse")
                {
                    for (int i = 0; i < line.Count; i++)
                    {
                        if (line[i] < value)
                        {
                            line.Remove(line[i]);
                            i = -1;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", line));
        }
    }
}