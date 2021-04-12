using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;

namespace LetsMeet.DataSetLogic
{
    public static class DataHelpers
    {
        public static IList<Meeting> SetPossibleMeetings()
        {
            IList<Meeting> posibleMeetings = new List<Meeting>();
            DateTime dateTime = DateTime.Today;

            for (int i = 0; i < 48; i++)
            {
                posibleMeetings.Add(
                    new Meeting(dateTime, dateTime += TimeSpan.FromMinutes(30)));
            }

            return posibleMeetings;
        }
    }
}
