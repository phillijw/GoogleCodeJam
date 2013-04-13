using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace CodeJam2013.Round0.ProblemB
{
    class Runner : Runnable
    {
        public string Run(string input)
        {
            var lines = input.Replace("\r\n", "\n").Split('\n').ToList();
            var cases = lines.GetRange(1, lines.Count - 1);
            var caseCount = Int32.Parse(lines[0]);


            var output = new List<string>();
            var startingLine = 0;
            for (int i = 0; i < caseCount; i++)
            {
                var n = Int32.Parse(cases[startingLine].Split(' ')[0]);
                var caseLine = string.Join(" ", cases.GetRange(startingLine, n+1));
                var result = string.Format("Case #{0}: {1}", i+1, Case.Run(caseLine));
                Console.WriteLine(result);

                output.Add(result);
                startingLine += n+1;
            }

            return string.Join("\r\n", output);
        }
    }
}
