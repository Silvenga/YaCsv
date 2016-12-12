using System;
using System.IO;
using System.Linq;

using FluentAssertions;

using Ploeh.AutoFixture;

using Xunit;

using YaCsv.Engines;
using YaCsv.Models;

namespace YaCsv.Tests.Engines
{
    public class TokenizerEngineFacts
    {
        private static readonly Fixture Autofixture = new Fixture();

        [Fact]
        public void GetRecords_breaks_by_column_deliminator()
        {
            var options = Autofixture.Create<CsvOptions>();
            var records = Autofixture.CreateMany<string>().ToList();
            var csv = string.Join(options.RowDeliminator, records);
            var memory = StringToMemoryStream(csv);

            var engine = new TokenizerEngine(options);

            // Act
            var result = engine.GetRecords(memory).ToList();

            // Assert
            result.Should().BeEquivalentTo(records);
        }

        [Fact]
        public void GetFields_breaks_by_row_deliminator()
        {
            var records = Autofixture.CreateMany<string>().ToList();
            var csv = string.Join(",", records);
            var memory = StringToMemoryStream(csv);

            var engine = new TokenizerEngine(new Rfc4180CsvOptions());

            // Act
            var result = engine.GetFields(memory).ToList();

            // Assert
            result.Should().BeEquivalentTo(records);
        }

        private static MemoryStream StringToMemoryStream(string str)
        {
            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            writer.Write(str);
            writer.Flush();
            memory.Position = 0;
            return memory;
        }
    }
}