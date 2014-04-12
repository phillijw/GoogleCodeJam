using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam2014.Round0.ProblemA
{
    static class Case
    {
        public static string Run(string rawCase)
        {

            var arrangement1 = rawCase.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Take(1+16);
            var arrangement2 = rawCase.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Skip(1+16).Take(1+16);

            var arrangement1row = Int32.Parse(arrangement1.First());
            var arrangement2row = Int32.Parse(arrangement2.First());

            var rowA = arrangement1.Skip(1).Skip(arrangement1row * 4 - 4).Take(4); //Skip the "answer"; Skip past first X rows then back track to beginning of row; Take 4 items in row
            var rowB = arrangement2.Skip(1).Skip(arrangement2row * 4 - 4).Take(4);

            var intersection = rowA.Intersect(rowB);

            if (intersection.Count() == 1)
                return intersection.Single();

            if (intersection.Count() > 1)
                return "Bad magician!";

            if (intersection.Count() == 0)
                return "Volunteer cheated!";

            throw new Exception("Something bad happened");

        }

    }
}
