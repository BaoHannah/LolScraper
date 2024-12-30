using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApiScraper
{
    public static class Utility
    {
        public static long ConvertToUnixTimestamp(DateTime timestamp)
        {
            DateTime origin = DateTime.UnixEpoch;
            TimeSpan diff = timestamp.ToUniversalTime() - origin;
            return (long)Math.Floor(diff.TotalSeconds);
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = DateTime.UnixEpoch;
            return origin.AddSeconds(timestamp);
        }

        public static long ConvertToUnixMilliseconds(DateTime timestamp)
        {
            DateTime origin = DateTime.UnixEpoch;
            TimeSpan diff = timestamp.ToUniversalTime() - origin;
            return (long)Math.Floor(diff.TotalMilliseconds);
        }
    }
}
