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

            var output = new List<string>();
            for (int i = 0; i < caseCount; i++)
            {
                var result = string.Format("Case #{0}: {1}", i + 1, Case.Run(cases.Substring(i * 16, 16)));
                Console.WriteLine(result);

                output.Add(result);
            }

            return string.Join("\r\n", output);
        }
    }
}
