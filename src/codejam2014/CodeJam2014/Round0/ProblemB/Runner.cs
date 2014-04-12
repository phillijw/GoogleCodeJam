using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace CodeJam2014.Round0.ProblemB
{
    class Runner : Runnable
    {
        public string Run(string input)
        {
            input = input.Replace("\r\n", "\n");
            input = input.Replace("\n\n", "\n"); //Get rid of empty lines because they'll just get in the way
            var rawLines = input.Split('\n').ToList();
            var caseCount = Int32.Parse(rawLines[0]);
            var lines = input.Substring(input.IndexOf("\n")).Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var output = new List<string>();
            for (int i = 0; i < caseCount; i++)
            {
                var result = string.Format("Case #{0}: {1}", i + 1, Case.Run(lines[i]));
                Console.WriteLine(result);

                output.Add(result);
            }

            return string.Join("\r\n", output);
        }
    }
}
