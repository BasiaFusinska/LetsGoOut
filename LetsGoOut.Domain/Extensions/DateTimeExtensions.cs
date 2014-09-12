using System;

namespace LetsGoOut.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundUp(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour + 1, 0, 0);
        }
    }
}
