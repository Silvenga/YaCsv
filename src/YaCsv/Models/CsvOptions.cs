using System;

namespace YaCsv.Models
{
    public class CsvOptions
    {
        public string ColumnDeliminator { get; set; }
        public string RowDeliminator { get; set; }
        public char FieldQuoter { get; set; }
    }

    public class Rfc4180CsvOptions : CsvOptions
    {
        public Rfc4180CsvOptions()
        {
            ColumnDeliminator = ",";
            RowDeliminator = Environment.NewLine;
            FieldQuoter = '"';
        }
    }
}