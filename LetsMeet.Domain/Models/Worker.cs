using System.Collections.Generic;

namespace LetsMeet.Domain.Models
{
    public class Worker
    {
        public string Name { get; set; }
        public WorkingHours WorkingHours { get; set; }
        public List<Meeting> Meetings { get; set; }
    }
}
