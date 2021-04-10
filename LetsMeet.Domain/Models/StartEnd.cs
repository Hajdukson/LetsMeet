using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.Domain.Models
{
    public class StartEnd
    {
        public StartEnd()
        {

        }
        public StartEnd(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
