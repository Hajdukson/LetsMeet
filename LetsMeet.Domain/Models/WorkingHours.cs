using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.Domain.Models
{
    public class WorkingHours : StartEnd
    {
        public WorkingHours()
        {

        }
        public WorkingHours(DateTime start, DateTime end) : base(start, end)
        {
        }
    }
}
