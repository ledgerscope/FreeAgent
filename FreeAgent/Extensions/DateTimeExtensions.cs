using System;

namespace FreeAgent.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToTrialBalanceFilterTime(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        public static string ToTrialBalanceFilterTime(this DateTime? dt)
        {
            if (dt.HasValue)
                return dt.Value.ToTrialBalanceFilterTime();
            else
                return string.Empty;
        }
    }
}
