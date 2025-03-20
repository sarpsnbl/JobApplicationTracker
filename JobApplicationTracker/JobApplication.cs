using System;
using System.Collections.Generic;

namespace JobTrackerApp
{
    public class JobApplication
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public DateTime DateApplied { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string Notes { get; set; }

        // New properties for reminders and website
        public string Website { get; set; }
        public DateTime? ReminderDate { get; set; }
    }
}