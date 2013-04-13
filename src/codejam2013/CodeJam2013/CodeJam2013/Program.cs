using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace CodeJam2013
{
    class Program
    {
        static void Main(string[] args)
        {
            // Choose which runner to use
            //----------------------------
            Assembly assembly = Assembly.GetExecutingAssembly();
            var runners = assembly.GetTypes().Where(p => p.Name == "Runner").OrderBy(p => p.FullName).ToList(); //All "runners" will 

            Console.WriteLine();
            Console.WriteLine(" Which runner would you like to use? ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            if (runners.Count == 0)
            {
                Console.WriteLine(" -- No choices available --");
                Console.WriteLine();
            }

            for (int i=0; i < runners.Count; i++)
            {
                Console.WriteLine(string.Format(" {0}) {1}", i, runners[i].FullName));
                Console.WriteLine();
            }


            string runnerChoiceInput = string.Empty;
            int runnerChoice;

            while (!Int32.TryParse(runnerChoiceInput, out runnerChoice) || (runnerChoice >= runners.Count || runnerChoice < 0))
            {
                Console.Write("> ");
                runnerChoiceInput = Console.ReadLine();
            }


            // Choose which input file to use
            //--------------------------------
            Console.WriteLine();
            Console.WriteLine(" Which input file would you like to use? ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();

            //make list of files
            var processDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var inputFiles = Directory.GetFiles(processDirectory, "*.in", SearchOption.AllDirectories).Select(f => new FileInfo(f)).OrderBy(f => f.FullName).ToList();
            //Console.WriteLine(files[0].Replace(processDirectory, ""));

            if (inputFiles.Count == 0)
            {
                Console.WriteLine(" -- No choices available --");
                Console.WriteLine();
            }

            for (int i = 0; i < inputFiles.Count; i++)
            {
                Console.WriteLine(string.Format(" {0}) {1}", i, inputFiles[i].FullName.Replace(processDirectory, "")));
                Console.WriteLine();
            }

            string fileChoiceInput = string.Empty;
            int fileChoice = Int32.MaxValue;

            while (!Int32.TryParse(fileChoiceInput, out fileChoice) || (fileChoice >= inputFiles.Count || fileChoice < 0))
            {
                Console.Write("> ");
                fileChoiceInput = Console.ReadLine();
            }


            // Alright. Let's run this thing
            //-------------------------------
            Console.WriteLine("Hit [Enter] to run");
            Console.ReadLine();
            var runner = (Runnable)assembly.CreateInstance(runners[runnerChoice].FullName);
            var reader = new StreamReader(inputFiles[fileChoice].FullName);
            var input = reader.ReadToEnd();
            reader.Close();
            var startTime = DateTime.Now;

            var output = runner.Run(input);
            writeOutput(new FileInfo("output.txt"), output);
            
            var endTime = DateTime.Now;

            Console.WriteLine(string.Format("Finished running in {0} seconds", (endTime-startTime).Seconds));
            Console.WriteLine("Hit [Enter] to exit");
            Console.ReadLine();
        }

        private static void writeOutput(FileInfo file, string contents)
        {
            File.WriteAllText(file.FullName, contents);
        }
    }
}
