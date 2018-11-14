using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalApp.Api.Helpers
{
    public static class AppSettingsProvider
    {
        public static int HoursByMonth { get; set; }
        public static int MonthsByYear { get; set; }
        public static string ApiUrl { get; set; }

    }
}
