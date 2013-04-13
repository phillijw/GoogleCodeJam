using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam2013.Round0.ProblemB
{
    static class Case
    {
        public static string Run(string input)
        {
            var inputArray = input.Split(' ');
            int n = Int32.Parse(inputArray[0]);
            int m = Int32.Parse(inputArray[1]);
            var lawn = inputArray.ToList().GetRange(2, inputArray.Length - 2);
            var lawnInts = lawn.Select(int.Parse).ToList();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (IsAccessible(lawnInts, m, n, j, i))
                        continue;
                    else
                        return "NO";
                }
            }

            return "YES";
        }

        private static bool IsAccessible(List<int> lawn, int m, int n, int x, int y)
        {
            return IsHorizontallyAccessible(lawn, m, n, x, y) || IsVerticallyAccessible(lawn, m, n, x, y);
        }

        private static bool IsHorizontallyAccessible(List<int> lawn, int m, int n, int x, int y)
        {
            //Is there any taller grass in this row?
            var row = lawn.GetRange(y * m, m);
            var accessible = row.Max() <= lawn[y*m+x];
            return accessible;
        }

        private static bool IsVerticallyAccessible(List<int> lawn, int m, int n, int x, int y)
        {
            //Is there any taller grass in this column?
            var col = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j=0; j < m; j++)
                {
                    if (j == x)
                        col.Add(lawn[i * m + j]);
                }
            }

            var accessible = col.Max() <= lawn[y * m + x];
            return accessible;
        }
    }
}
