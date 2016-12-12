using System.Collections.Generic;
using System.IO;

using YaCsv.Models;

namespace YaCsv.Engines
{
    public class TokenizerEngine
    {
        private readonly CsvOptions _options;

        public TokenizerEngine(CsvOptions options)
        {
            _options = options;
        }

        public IEnumerable<string> GetRecords(Stream stream)
        {
            var reader = new StreamReader(stream);
            var delimiter = _options.RowDeliminator.ToCharArray();

            while (!reader.EndOfStream)
            {
                var record = ReadUntillReturnDelimiter(reader, delimiter);
                yield return new StreamReader(record).ReadToEnd();
            }
        }

        public IEnumerable<string> GetFields(Stream stream)
        {
            var reader = new StreamReader(stream);

            

            yield return null;
        }

        private static Stream ReadUntillReturnDelimiter(StreamReader reader, IReadOnlyList<char> delimiter)
        {
            var memory = new MemoryStream();
            var builder = new StreamWriter(memory);

            var lastMatch = 0;

            while (!reader.EndOfStream && lastMatch != delimiter.Count)
            {
                var c = (char) reader.Read();
                if (delimiter[lastMatch] == c)
                {
                    lastMatch++;
                }
                else
                {
                    builder.Write(c);
                }
            }

            builder.Flush();
            memory.Position = 0;
            return memory;
        }
    }
}