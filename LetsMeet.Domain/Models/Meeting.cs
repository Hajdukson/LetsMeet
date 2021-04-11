using System;

namespace LetsMeet.Domain.Models
{
    public class Meeting : StartEnd
    {
        public Meeting(DateTime start, DateTime end) : base(start, end)
        {
            TimeSpan timeSpan = (end - start);
            if (!(timeSpan >= TimeSpan.FromMinutes(30)))
                throw new ArgumentException("the duration of the meeting should be no shorter than 30 minutes");
        }
    }
}
