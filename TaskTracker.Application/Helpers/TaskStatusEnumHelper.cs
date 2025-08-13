using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Helpers
{
    internal static class TaskStatusEnumHelper
    {
        public static String GetTaskStatusString(TaskStatusEnum status)
        {
            string returnVal = status switch
            {
                TaskStatusEnum.Pending => nameof(TaskStatusEnum.Pending),
                TaskStatusEnum.InProgress => nameof(TaskStatusEnum.InProgress),
                TaskStatusEnum.Completed => nameof(TaskStatusEnum.Completed),
                _ => ""
            };

            return returnVal;
        }
    }
}
