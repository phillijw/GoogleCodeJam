using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam2013.Round0.ProblemC
{
    static class Case
    {
        public static string Run(string input)
        {
            var inputArray = input.Split(' ');
            int start = Int32.Parse(inputArray[0]);
            int end = Int32.Parse(inputArray[1]);

            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (IsFairAndSquare(i))
                    count++;
                    //Console.WriteLine(string.Format("{0} is fair and square", i));
            }

            return count.ToString();
        }


        private static bool IsFairAndSquare(int num)
        {
            return IsFair(num) && IsSquare(num);
        }

        private static bool IsSquare(int num)
        {
            var result = Math.Sqrt(num);
            var floor = Math.Floor(result);
            var ceil = Math.Ceiling(result);
            return floor == ceil && IsFair(Math.Sqrt(num));
        }

        private static bool IsFair(int num)
        {
            var intForwards = string.Join("", num.ToString());
            var intBackwards = string.Join("", intForwards.Reverse());

            return intForwards == intBackwards;
        }

        private static bool IsFair(double num)
        {
            if (Math.Ceiling(num) != Convert.ToInt32(num))
                return false;

            var intForwards = string.Join("", num.ToString());
            var intBackwards = string.Join("", intForwards.Reverse());

            return intForwards == intBackwards;
        }
    }
}
