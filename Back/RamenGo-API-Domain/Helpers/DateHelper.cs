using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Helpers
{
    public static class DateHelper
    {
        public static DateTime GetDateTimeBrazil()
        {
            TimeZoneInfo timeZoneInfo;

            try
            {
                //Try searching for the Windows time zone
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            catch (Exception)
            {
                //Try searching for the Linux timezone
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }

            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
        }
    }
}
