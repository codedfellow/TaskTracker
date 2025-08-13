using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Shared.Helpers
{
    public static class EnumHelper
    {
        public static string GetTasktatusString(ScheduledMailStatus status)
        {
            string returnVal = status switch
            {
                ScheduledMailStatus.Active => nameof(ScheduledMailStatus.Active),
                ScheduledMailStatus.Cancelled => nameof(ScheduledMailStatus.Cancelled),
                ScheduledMailStatus.Ended => nameof(ScheduledMailStatus.Ended),
                _ => ""
            };

            return returnVal;
        }
    }
}
