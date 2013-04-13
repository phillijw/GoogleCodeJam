using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace CodeJam2013.Round0.ProblemC
{
    class Runner : Runnable
    {
        public string Run(string input)
        {
            var lines = input.Replace("\r\n", "\n").Split('\n').ToList();
            var cases = lines.GetRange(1, lines.Count - 1);
            var caseCount = Int32.Parse(lines[0]);


            var output = new List<string>();
            for (int i = 0; i < caseCount; i++)
            {
                var result = string.Format("Case #{0}: {1}", i+1, Case.Run(cases[i]));
                Console.WriteLine(result);

                output.Add(result);
            }

            return string.Join("\r\n", output);
        }
    }
}
