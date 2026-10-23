using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace DLIB
{
    public static class SearchFilter
    {
        public static string Build(DataTable table, string text, string column = null)
        {
            if (table == null || string.IsNullOrWhiteSpace(text)) return string.Empty;
            var expressions = new List<string>();
            foreach (DataColumn field in table.Columns)
            {
                if (!string.IsNullOrEmpty(column) && field.ColumnName != column) continue;
                string name = "[" + field.ColumnName.Replace("\\", "\\\\").Replace("]", "\\]") + "]";
                if (field.DataType == typeof(string))
                    expressions.Add(name + " LIKE '%" + EscapeLike(text.Trim()) + "%'");
                else if (IsNumber(field.DataType))
                {
                    decimal number;
                    if (decimal.TryParse(text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out number))
                        expressions.Add(name + " = " + number.ToString(CultureInfo.InvariantCulture));
                }
            }
            return expressions.Count == 0 ? "1 = 0" : string.Join(" OR ", expressions);
        }

        private static bool IsNumber(Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) ||
                type == typeof(ushort) || type == typeof(int) || type == typeof(uint) ||
                type == typeof(long) || type == typeof(ulong) || type == typeof(float) ||
                type == typeof(double) || type == typeof(decimal);
        }

        private static string EscapeLike(string text)
        {
            var result = new StringBuilder();
            foreach (char value in text)
            {
                switch (value)
                {
                    case '\'': result.Append("''"); break;
                    case '[': result.Append("[[]"); break;
                    case ']': result.Append("[]]"); break;
                    case '%': result.Append("[%]"); break;
                    case '*': result.Append("[*]"); break;
                    default: result.Append(value); break;
                }
            }
            return result.ToString();
        }
    }
}
