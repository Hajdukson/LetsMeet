using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;

namespace LetsMeet.DataSetLogic
{
    public class DataSetter
    {
        public bool CanAddMeeting(Worker worker, Meeting newMeeting)
        {
            if (worker.WorkingHours.Start.CompareTo(newMeeting.Start) < 0
                && worker.WorkingHours.End.CompareTo(newMeeting.End) > 0)
            {
                IEnumerable<Meeting> meetings = worker.Meetings;
                foreach (var meeting in meetings)
                {
                    if (!(meeting.Start.CompareTo(newMeeting.Start) < 0
                        || meeting.End.CompareTo(newMeeting.End) > 0))
                        return false;
                }
                return true;
            }
            return false;
        }
        public WorkingHours SetInterval(Worker firstworker, Worker secoundworker)
        {
            WorkingHours firstWokrerWorkingHours = firstworker.WorkingHours;
            WorkingHours secoundWorkerWorkingHours = secoundworker.WorkingHours;

            WorkingHours workingHours = new WorkingHours();

            if (firstWokrerWorkingHours.Start.CompareTo(secoundWorkerWorkingHours.Start) >= 0)
                workingHours.Start = firstWokrerWorkingHours.Start;
            else
                workingHours.Start = secoundWorkerWorkingHours.Start;

            if (firstWokrerWorkingHours.End.CompareTo(secoundWorkerWorkingHours.End) <= 0)
                workingHours.End = firstWokrerWorkingHours.End;
            else
                workingHours.End = secoundWorkerWorkingHours.End;

            return workingHours;
        }

        public string WhenWorkersCanMeetTogether(Worker firstworker, Worker secoundworker)
        {
            ICollection<Meeting> firstWorkerMeetings = firstworker.Meetings;
            ICollection<Meeting> secoundWorkerMeetings = secoundworker.Meetings;

            WorkingHours interval = SetInterval(firstworker, secoundworker);


            return "";
        }
    }
}
