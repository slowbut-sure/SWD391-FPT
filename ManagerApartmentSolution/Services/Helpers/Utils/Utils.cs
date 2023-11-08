using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers.Utils
{
    public static class Utils
    {
        public static DateTime GetClientDateTime()
        {
            DateTime serverDateTime = DateTime.UtcNow;
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            DateTime clientDateTime = TimeZoneInfo.ConvertTimeFromUtc(serverDateTime, vietnamTimeZone);

            return clientDateTime;
        }
    }
}
