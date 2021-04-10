using System;

namespace LetsMeet.Domain.Models
{
    public class Meeting : StartEnd
    {
        public Meeting(DateTime start, DateTime end) : base(start, end)
        {
            TimeSpan checkeMeetingDuration = (end - start);
        }
    }
}
