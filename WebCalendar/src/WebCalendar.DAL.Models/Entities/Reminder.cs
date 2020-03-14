using System;
using System.Collections.Generic;

namespace WebCalendar.DAL.Models.Entities
{
    public class Reminder : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }  
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan? RepetitionInterval { get; set; }
        public int? RepetitionsCount { get; set; }
        public DateTime? RepetitionsEndTime { get; set; }

        public Guid CalendarId { get; set; }
        public Calendar Calendar { get; set; }
        public ICollection<ReminderDay> ReminderDays { get; set; }
    }
}