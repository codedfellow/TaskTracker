using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Domain.Entities
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Guid AssignedToUserId { get; set; }
        public User AssignedTo { get; set; }
    }
}
