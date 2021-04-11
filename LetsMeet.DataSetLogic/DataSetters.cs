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

            //Console.WriteLine($"I: {interval.Start} || {interval.End}" + Environment.NewLine);

            //foreach (var firstWorkerMeetingInInterval in firstWorkerMeetingsInInterval)
            //{
            //    Console.WriteLine($"F: {firstWorkerMeetingInInterval.Start} || {firstWorkerMeetingInInterval.End}");
            //}

            //Console.WriteLine();

            //foreach (var secoundWorkerMeetingInInterval in secoundWorkerMeetingsInInterval)
            //{
            //    Console.WriteLine($"S: {secoundWorkerMeetingInInterval.Start} || {secoundWorkerMeetingInInterval.End}");
            //}
            //List<Meeting> expectedMeetings = new List<Meeting>
            //{
            //    new Meeting(DateTime.Parse("11:30"),  DateTime.Parse("12:00")),
            //    new Meeting(DateTime.Parse("15:00"), DateTime.Parse("16:00")),
            //    new Meeting(DateTime.Parse("18:00"), DateTime.Parse("18:30"))
            //};

            IList<Meeting> listOfMeetingBothOfWorkers = new List<Meeting>();
            IList<Meeting> possibleMeetings = SetPossibleMeetings();

            foreach (var meeting in firstWorkerMeetingsInInterval)
            {
                listOfMeetingBothOfWorkers.Add(meeting);
            }
            foreach (var meeting in secoundWorkerMeetingsInInterval)
            {
                listOfMeetingBothOfWorkers.Add(meeting);
            }

            var testmettings = listOfMeetingBothOfWorkers.OrderBy(m => m.Start);

            Worker worker = new Worker();
            List<Meeting> meetings = new List<Meeting>();

            foreach (var test in testmettings)
            {
                meetings.Add(test);
            }

            worker.WorkingHours = interval;
            worker.Meetings = meetings;

            foreach (var meeting in worker.Meetings)
            {
                Console.WriteLine($"{meeting.Start} || {meeting.End}");
            }
            Meeting newMetting = new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00"));

            int i = 0;

            List<Meeting> newMettings = new List<Meeting>();
            foreach (var possible in possibleMeetings)
            {
                if (CanAddMeeting(worker, possible))
                    newMettings.Add(possible);
            }

            List<Meeting> meetings1 = newMettings;


            return new List<Meeting>();
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


        public IList<Meeting> DeletMeetingOutOfInterval(IList<Meeting> meetings, WorkingHours interval)
        {
            return meetings.Where((m => interval.End.CompareTo(m.Start) > 0)
                                        ).ToList().Where(m => interval.Start.CompareTo(m.End) < 0).ToList();
        }

        private IList<Meeting> SetPossibleMeetings()
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
        private IList<Meeting> SetBusyTime(List<Meeting> meetings)
        {
            IList<Meeting> result = new List<Meeting>();
            int i = 0;
            foreach (var meeting in meetings)
            {
                if(meeting.End.CompareTo(meetings[i + 1].Start) > 0)
            }

            return result;
        }
    }
}
