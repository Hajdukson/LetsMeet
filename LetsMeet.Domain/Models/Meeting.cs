using System;

namespace LetsMeet.Domain.Models
{
    public class Meeting : StartEnd
    {
        public Meeting(double duration)
        {
            Duration = TimeSpan.FromMinutes(duration);
        }
        public Meeting(DateTime start, DateTime end) : base(start, end)
        {

        }
        public static TimeSpan Duration { get; set; }
        
    }
}
