using System;

namespace RonwellHR.Domain.Entities
{
    public class TrainingSession
    {
        public int TrainingSessionId { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
