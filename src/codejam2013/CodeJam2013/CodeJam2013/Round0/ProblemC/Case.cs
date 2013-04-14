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
            Int64 start = Int64.Parse(inputArray[0]);
            Int64 end = Int64.Parse(inputArray[1]);

            int count = 0;
            for (Int64 i = start; i <= end; i++)
            {
                if (IsFairAndSquare(i))
                    count++;
            }

            return count.ToString();
        }


        private static bool IsFairAndSquare(Int64 num)
        {
            return IsSquare(num) && IsFair(num);
        }

        private static bool IsSquare(Int64 num)
        {
            var result = Math.Sqrt(num);
            var floor = Math.Floor(result);
            var ceil = Math.Ceiling(result);
            return floor == ceil && IsFair(Math.Sqrt(num));

        }

        private static bool IsFair(Int64 num)
        {
            var intForwards = string.Join("", Convert.ToString(num));
            var intBackwards = string.Join("", intForwards.Reverse());

            return intForwards == intBackwards;
        }

        private static bool IsFair(double num)
        {
            if (Math.Ceiling(num) != Convert.ToInt64(num))
                return false;

            var intForwards = string.Join("", Convert.ToString(num));
            var intBackwards = string.Join("", intForwards.Reverse());

            return intForwards == intBackwards;
        }
    }
}
