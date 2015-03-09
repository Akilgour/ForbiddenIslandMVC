using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Helpers
{
    public class ListStringToCSVString
    {
        public static string ListToString(List<string> stringList)
        {
            if (stringList == null)
            {
                return string.Empty;
            }

            string csvString = string.Join(", ", stringList.OrderBy(p => p.Substring(0)));
            var commaIndex = csvString.LastIndexOf(",");

            if (commaIndex != -1)
            {
                csvString = csvString.Remove(commaIndex, 1);
                csvString = csvString.Insert(commaIndex, " and");
            }

            return csvString;
        }

    }
}