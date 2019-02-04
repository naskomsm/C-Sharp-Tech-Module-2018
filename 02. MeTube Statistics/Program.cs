using System;
using System.Collections.Generic;
using System.Linq;

namespace CodePlace
{
    class Program
    {
        static void Main(string[] args) // 90/100 random bug
        {
            Dictionary<string, int[]> storage = new Dictionary<string, int[]>();

            // [0] = views
            // [1] = likes

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stats time")
                {
                    break;
                }

                // video information - name, views, likes
                if (input.Contains('-'))
                {
                    string[] splittedinput = input.Split('-');
                    string name = splittedinput[0];
                    string views = splittedinput[1];

                    if (!storage.ContainsKey(name))
                    {
                        storage.Add(name, new int[2]);
                        storage[name][0] = int.Parse(views);
                        storage[name][1] = 0;
                    }
                    else
                    {
                        storage[name][0] += int.Parse(views);
                    }
                }
                else if (input.Contains(':'))
                {
                    string[] splittedInput = input.Split(':');
                    string command = splittedInput[0];
                    string name = splittedInput[1];

                    if(command == "like")
                    {
                        if (storage.ContainsKey(name))
                        {
                            storage[name][1]++;
                        }
                    }
                    else if (command == "dislike")
                    {
                        if (storage.ContainsKey(name))
                        {
                            storage[name][1]--;
                            if (storage[name][1] <= 0)
                            {
                                storage[name][1] = 0;
                            }
                        }
                    }
                }
            }
            string sortByCommand = Console.ReadLine();

            if (sortByCommand == "by views")
            {
                storage = storage.OrderByDescending(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);
            }
            else if (sortByCommand == "by likes")
            {
                storage = storage.OrderByDescending(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value);
            }
            foreach (var kvp in storage)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value[0]} views - {kvp.Value[1]} likes");
            }


        //    // 100/100 s dve dictionaryta
        //    Dictionary<string, double> VideoAndViews = new Dictionary<string, double>();
        //    Dictionary<string, double> VideoAndLikes = new Dictionary<string, double>();

        //    while (true)
        //    {
        //        string input = Console.ReadLine();
        //        if (input == "stats time")
        //        {
        //            break;
        //        }

        //        // Video information - name and views
        //        if (input.Contains('-'))
        //        {
        //            string[] splittedInput = input.Split('-');
        //            string videoName = splittedInput[0];
        //            string views = splittedInput[1];

        //            if (!VideoAndViews.ContainsKey(videoName))
        //            {
        //                VideoAndViews.Add(videoName, double.Parse(views));
        //            }
        //            else
        //            {
        //                VideoAndViews[videoName] += double.Parse(views);
        //            }
        //            if (!VideoAndLikes.ContainsKey(videoName))
        //            {
        //                VideoAndLikes.Add(videoName, 0);
        //            }
        //        }
        //        else if (input.Contains(':'))
        //        {
        //            string[] splittedInput = input.Split(':');
        //            string command = splittedInput[0];
        //            string videoName = splittedInput[1];

        //            if (command == "like")
        //            {
        //                if (VideoAndViews.ContainsKey(videoName) && VideoAndLikes.ContainsKey(videoName))
        //                {
        //                    VideoAndLikes[videoName] += 1;
        //                }
        //            }
        //            else if (command == "dislike")
        //            {
        //                if (VideoAndViews.ContainsKey(videoName) && VideoAndLikes.ContainsKey(videoName))
        //                {
        //                    VideoAndLikes[videoName] -= 1;
        //                }
        //            }
        //        }
        //    }
        //    string sortByCommand = Console.ReadLine();
        //    if (sortByCommand == "by views")
        //    {
        //        var orderedDictionary = VideoAndViews.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        //        foreach (var kvp in orderedDictionary)
        //        {
        //            Console.Write($"{kvp.Key} - {kvp.Value} views - ");
        //            foreach (var KVP in VideoAndLikes)
        //            {
        //                if (KVP.Key == kvp.Key)
        //                {
        //                    Console.WriteLine($"{KVP.Value} likes");
        //                }
        //            }
        //        }
        //    }
        //    else if (sortByCommand == "by likes")
        //    {
        //        var orderDictionary = VideoAndLikes.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        //        foreach (var kvp in orderDictionary)
        //        {
        //            foreach (var KVP in VideoAndViews)
        //            {
        //                if (KVP.Key == kvp.Key)
        //                {
        //                    Console.Write($"{KVP.Key} - {KVP.Value} views - ");
        //                    Console.WriteLine($"{kvp.Value} likes");
        //                }
        //            }

        //        }
        //    }
        //}
    }
    }
}
