using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam2013
{
    /// <summary>
    /// Takes care of some common file reading stuff
    /// </summary>
    class SampleInputReader
    {
        private FileInfo file;
        private List<string> lines;

        public SampleInputReader(FileInfo file)
        {
            this.file = file;
        }

        public SampleInputReader(string filePath)
        {
            this.file = new FileInfo(filePath);
        }

        public void LoadFile()
        {
            if (!file.Exists)
                throw new FileNotFoundException(string.Format("File not found: {0}", file.FullName));

            this.lines = File.ReadLines(file.FullName).ToList();
        }

        public string GetLine(int lineNum)
        {
            if (lines == null)
                throw new InvalidOperationException("Must load file before retreiving a line");

            if (lineNum >= lines.Count)
                throw new InvalidOperationException("Requested line number does not exist");

            return lines[lineNum];
        }

    }
}
