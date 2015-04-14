using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace LolStatistics.DataAccess.Extensions
{
    public static class DbCommandExtension
    {
        public static void AddWithValue(this DbCommand command, string paramName, object value)
        {
            Regex regex = new Regex("@[A-Z;a-z;0-9]*");
            MatchCollection matches = regex.Matches(command.CommandText);
            command.Parameters.Add(value);
        }
    }
}
