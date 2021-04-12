using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;

namespace LetsMeet.DataSetLogic
{
    public static class DataHelpers
    {
        //public static IList<Meeting> SetAbstractMeetings()
        //{
        //    IList<Meeting> posibleMeetings = new List<Meeting>();
        //    DateTime dateTime = DateTime.Today;

        //    for (int i = 0; i < 48; i++)
        //    {
        //        posibleMeetings.Add(
        //            new Meeting(dateTime, dateTime += TimeSpan.FromMinutes(30)));
        //    }

        //    return posibleMeetings;
        //}

        //public bool CanAddMeeting(Worker worker, Meeting newMeeting)
        //{
        //    if (worker.WorkingHours.Start.CompareTo(newMeeting.Start) < 0
        //        && worker.WorkingHours.End.CompareTo(newMeeting.End) > 0)
        //    {
        //        IEnumerable<Meeting> meetings = worker.Meetings;
        //        foreach (var meeting in meetings)
        //        {
        //            if (!(meeting.Start.CompareTo(newMeeting.Start) < 0
        //                || meeting.End.CompareTo(newMeeting.End) > 0))
        //                return false;
        //        }
        //        return true;
        //    }

        //    return false;
        //}
    }
}
