using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace CodeJam2013.Round0.ProblemD
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
                var k = Int32.Parse(cases[startingLine].Split(' ')[0]);
                var n = Int32.Parse(cases[startingLine].Split(' ')[1]);
                var caseLines = string.Join("\n", cases.GetRange(startingLine, n+2));
                var result = string.Format("Case #{0}: {1}", i+1, Case.Run(caseLines));
                Console.WriteLine(result);

                output.Add(result);
                startingLine += n+1;
            }

            return string.Join("\r\n", output);
        }
    }
}
