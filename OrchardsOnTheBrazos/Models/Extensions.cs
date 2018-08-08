using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrchardsOnTheBrazos.Models
{
    public static class Extensions
    {
        //datetime
        public static string ToShortDateString(this DateTime date)
        {
            return date.ToString("YYYY/MM/DD");
        }
        //nullable datetime
        public static string ToShortDateString(this DateTime? date)
        {
            if (date == null)
            {
                return null;
            }
            return date.Value.ToShortDateString();
        }

    }
}