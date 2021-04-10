using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsMeet.DataSetLogic
{
    public class DataSetters
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
        public IList<Meeting> WhenWorkersCanMeetTogether(Worker firstworker, Worker secoundworker)
        {
            IList<Meeting> firstWorkerMeetings = firstworker.Meetings;
            IList<Meeting> secoundWorkerMeetings = secoundworker.Meetings;

            WorkingHours interval = SetInterval(firstworker, secoundworker);

            ICollection<Meeting> firstWorkerMeetingsInInterval = DeletMeetingOutOfInterval(firstWorkerMeetings, interval);
            ICollection<Meeting> secoundWorkerMeetingsInInterval = DeletMeetingOutOfInterval(secoundWorkerMeetings, interval);

            foreach (var first in firstWorkerMeetingsInInterval)
            {
                Console.WriteLine($"{first.Start} || {first.End}");
            }

            Console.WriteLine();

            foreach (var secound in secoundWorkerMeetingsInInterval)
            {
                Console.WriteLine($"{secound.Start} || {secound.End}");
            }


            return new List<Meeting>();
        }
        private WorkingHours SetInterval(Worker firstworker, Worker secoundworker)
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


        private IList<Meeting> DeletMeetingOutOfInterval(IList<Meeting> meetings, WorkingHours interval)
        {
            return meetings.Where((m => interval.End.CompareTo(m.Start) > 0)
                                        ).ToList().Where(m => interval.Start.CompareTo(m.End) < 0).ToList();
        }
    }
}
