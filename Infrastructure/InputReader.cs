using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Infrastructure
{
    public class InputReader
    {
        public string[] GetInput(string fileName, Assembly assembly)
        {
            var inputLines = ReadInputLines(fileName, assembly);
            return inputLines.ToArray();
        }

        private IEnumerable<string> ReadInputLines(string fileName, Assembly assembly)
        {
            var result = ReadAllLines(() => assembly.GetManifestResourceStream(fileName));
            return result;
        }

        private IEnumerable<string> ReadAllLines(Func<Stream?> streamFactory)
        {
            var lines = new List<string>();
            using var stream = streamFactory();
            if (stream == null) return Array.Empty<string>();

            using var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }
}