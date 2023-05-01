using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.ReminderResponses
{
    public class ReminderResponse
    {
        public Guid Id { get; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ReminderResponse(Guid id, string description, string status)
        {
            Id = id;
            Description = description;
            Status = status;
        }

        public static ReminderResponse FromEntity(Reminder reminder)
        {
            return new ReminderResponse(reminder.Id, reminder.Description, reminder.Status);
        }
    }
}
