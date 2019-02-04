using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            var lessonsAndExercises = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "course start")
                {
                    break;
                }

                string[] splitInput = input.Split(':');
                string command = splitInput[0];
                string lessonTitle = splitInput[1];

                if (command == "Add")
                {
                    if (!lessonsAndExercises.Contains(lessonTitle))
                    {
                        lessonsAndExercises.Add(lessonTitle);
                    }
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(splitInput[2]);
                    if (!lessonsAndExercises.Contains(lessonTitle) && index >= 0 && index < lessonsAndExercises.Count)
                    {
                        lessonsAndExercises.Insert(index, lessonTitle);
                    }
                }

                else if (command == "Remove")
                {
                    if (lessonsAndExercises.Contains(lessonTitle))
                    {
                        lessonsAndExercises.Remove(lessonTitle);
                        if (lessonsAndExercises.Contains($"{lessonTitle}-Exercise"))
                        {
                            lessonsAndExercises.Remove($"{lessonTitle}-Exercise");
                        }
                    }
                }

                else if (command == "Swap")
                {
                    string lessonTitle2 = splitInput[2];
                    if (lessonsAndExercises.Contains(lessonTitle) && lessonsAndExercises.Contains(lessonTitle2))
                    {
                        int indexOfLessonTitle = lessonsAndExercises.IndexOf(lessonTitle);
                        int indexOfLessonTitle2 = lessonsAndExercises.IndexOf(lessonTitle2);

                        string temp = lessonsAndExercises[indexOfLessonTitle];
                        lessonsAndExercises.RemoveAt(indexOfLessonTitle);
                        lessonsAndExercises.Insert(indexOfLessonTitle, lessonTitle2);
                        lessonsAndExercises.RemoveAt(indexOfLessonTitle2);
                        lessonsAndExercises.Insert(indexOfLessonTitle2, temp);

                        if (lessonsAndExercises.Contains($"{lessonTitle}-Exercise"))
                        {
                            if (indexOfLessonTitle < lessonsAndExercises.Count)
                            {
                                int index = lessonsAndExercises.IndexOf($"{lessonTitle}-Exercise");
                                int updatedIndexOfLessonTitle = lessonsAndExercises.IndexOf(lessonTitle);
                                string temporary = lessonsAndExercises[index];
                                lessonsAndExercises.RemoveAt(index);
                                lessonsAndExercises.Insert(indexOfLessonTitle + 1, temporary);
                            }
                            if (indexOfLessonTitle == lessonsAndExercises.Count)
                            {
                                lessonsAndExercises.Add($"{lessonTitle}-Exercise");
                            }

                        }
                        else if (lessonsAndExercises.Contains($"{lessonTitle2}-Exercise"))
                        {
                            if (indexOfLessonTitle2 < lessonsAndExercises.Count)
                            {
                                int index = lessonsAndExercises.IndexOf($"{lessonTitle2}-Exercise");
                                int updatedIndexOfLessonTitle2 = lessonsAndExercises.IndexOf(lessonTitle2);
                                string temporary = lessonsAndExercises[index];
                                lessonsAndExercises.RemoveAt(index);
                                lessonsAndExercises.Insert(updatedIndexOfLessonTitle2 + 1, temporary);
                            }
                            if (indexOfLessonTitle2 == lessonsAndExercises.Count)
                            {
                                lessonsAndExercises.Add($"{lessonTitle2}-Exercise");
                            }
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    if (!lessonsAndExercises.Contains($"{lessonTitle}-Exercise") && lessonsAndExercises.Contains(lessonTitle))
                    {
                        for (int i = 0; i < lessonsAndExercises.Count; i++)
                        {
                            if (lessonsAndExercises[i] == lessonTitle)
                            {
                                lessonsAndExercises.Insert(i + 1, $"{lessonTitle}-Exercise");
                            }
                        }
                    }
                    else if (!lessonsAndExercises.Contains($"{lessonTitle}-Exercise") && !lessonsAndExercises.Contains(lessonTitle))
                    {
                        lessonsAndExercises.Add(lessonTitle);
                        lessonsAndExercises.Add($"{lessonTitle}-Exercise");
                    }


                }
            }

            int counter = 1;
            for (int i = 0; i < lessonsAndExercises.Count; i++)
            {
                Console.WriteLine($"{counter}.{lessonsAndExercises[i]}");
                counter++;
            }
        }
    }
}