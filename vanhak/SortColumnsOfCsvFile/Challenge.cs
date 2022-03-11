using System;
using System.Collections.Generic;
using System.Linq;

namespace SortColumnsOfCsvFile
{
    public class Challenge
    {
        private const char COLUMN_JOIN = ',';
        private const char LINE_SEPARATOR = '\n';
        public static string SortCsvColumns(string csvData)
        {
            if (string.IsNullOrWhiteSpace(csvData))
            {
                return null;
            }
            var columns = ToColumns(csvData);
            var gfdg = ToCsv(columns.OrderBy(m => m.Values.First()).ToList());
            return gfdg;
        }

        private static List<Column> ToColumns(string csvData)
        {
            var rows = csvData.Split(LINE_SEPARATOR).Select(s => s.Split(COLUMN_JOIN)).ToArray();
            var columnsCount = rows.First().Count();
            var rowsCount = rows.Count();
            var columns = new List<Column>();
            for (var i = 0; i < columnsCount; i++)
            {
                var c = new Column
                {
                    Values = new string[rowsCount]
                };
                for (var j = 0; j < rowsCount; j++)
                {
                    var v = rows[j][i];
                    c.Values[j] = string.IsNullOrWhiteSpace(v) ? string.Empty : v;
                }
                columns.Add(c);
            }
            return columns;
        }

        private static string ToCsv(List<Column> columns)
        {
            var r = new List<string>();
            var columnsCount = columns.Count();
            var rowsCount = columns.First().Values.Count();
            for (var i = 0; i < rowsCount; i++)
            {
                var s = new List<string>();
                for (var j = 0; j < columnsCount; j++)
                {
                    s.Add(columns[j].Values[i]);
                }
                r.Add(string.Join(COLUMN_JOIN, s));
            }
            return string.Join(LINE_SEPARATOR, r);
        }

        public class Column
        {
            public string[] Values { get; set; }
        }
    }
}
