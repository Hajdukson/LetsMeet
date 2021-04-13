using System;

namespace LetsMeet.Domain.Models
{
    public class Meeting : StartEnd
    {
        /// <summary>
        /// Use this constructor to specify a meeting duration for both workers. It sets a static property Duration.
        /// </summary>
        /// <param name="duration"></param>
        public Meeting(double duration)
        {
            Duration = TimeSpan.FromMinutes(duration);
        }
        /// <summary>
        /// Sets start and end of the meeting
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Meeting(DateTime start, DateTime end) : base(start, end)
        {

        }
        public static TimeSpan Duration { get; set; }
        
    }
}
