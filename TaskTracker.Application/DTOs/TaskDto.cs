using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.DTOs
{
    public record TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Guid AssignedToUserId { get; set; }
        public string? AssignedToUserEmail { get; set; }
        public string? StatusText { get; set; }
    }
}
