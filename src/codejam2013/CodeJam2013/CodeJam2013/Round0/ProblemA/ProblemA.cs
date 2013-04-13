using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace CodeJam2013.Round0.ProblemA
{
    class Runner : Runnable
    {
        public string Run(string input)
        {
            input = input.Replace("\r\n", "\n");
            input = input.Replace("\n\n", "\n"); //Get rid of empty lines because they'll just get in the way
            var lines = input.Split('\n').ToList();
            var caseCount = Int32.Parse(lines[0]);
            var cases = input.Substring(input.IndexOf("\n")).Replace("\n", "");

            //Console.Write(cases);


            for (int i = 0; i < caseCount; i++)
            {
                Console.WriteLine(Case.Run(cases.Substring(i*16, 16)));
            }

            //Do nothing... so far
            return "test";
        }
    }
}
