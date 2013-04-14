using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam2013.Round0.ProblemD
{
    static class Case
    {
        public static string Run(string input)
        {
            var lines = input.Split('\n').ToList();
            var k = Int32.Parse(lines[0].Split(' ')[0]); //Number of keys you start with
            var n = Int32.Parse(lines[0].Split(' ')[1]); //Number of chests to open
            var keys = lines[1].Split(' ').Select(int.Parse).ToList(); //List of keys you start with
            var chests = lines.GetRange(2, n).ToList(); //List of chests with keys inside

            //Go down a path and see if it works
            //if it does, add it to a list then move to next path
            //If you have two, choose lexographically smallest
            Console.WriteLine(UnlockChests(keys, chests.Select(c => new Chest(c)).ToList()));
            //... blah, time ran out

            return "9 9 9 9";
        }

        //Goal: Given a list of chests, return which order produces the longest list of chests
        private static string UnlockChests(List<int> keys, List<Chest> unopenedChests)
        {

            return "";
        }

    }

    public class Chest
    {
        int ID { get; set; }
        int KeyHole { get; set; }
        List<int> Keys { get; set; }

        public Chest(string line)
        {
            var all = line.Split(' ').Select(int.Parse).ToList();
            KeyHole = Int32.Parse(line.Split(' ')[0]);
            var keyCount = Int32.Parse(line.Split(' ')[1]);
            Keys = new List<int>();

            for (int i = 0; i < keyCount; i++)
            {
                Keys.Add(all[i + 2]);
            }
        }

    }
}
