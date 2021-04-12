using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsMeet.DataSetLogic
{
    public class DataSetters
    {
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
        public IList<Meeting> WhenWorkersCanMeetTogether(Worker firstworker, Worker secoundworker)
        {
            IList<Meeting> firstWorkerMeetings = firstworker.Meetings;
            IList<Meeting> secoundWorkerMeetings = secoundworker.Meetings;

            WorkingHours interval = SetInterval(firstworker, secoundworker);

            ICollection<Meeting> firstWorkerMeetingsInInterval = DeletMeetingOutOfInterval(firstWorkerMeetings, interval);
            ICollection<Meeting> secoundWorkerMeetingsInInterval = DeletMeetingOutOfInterval(secoundWorkerMeetings, interval);

            //Worker worker = CreatAbstractWorker(firstWorkerMeetingsInInterval, listOfMeetingBothOfWorkers);

            IList<Meeting> listOfMeetingBothOfWorkers = new List<Meeting>();

            foreach (var meeting in firstWorkerMeetingsInInterval)
                listOfMeetingBothOfWorkers.Add(meeting);
            foreach (var meeting in secoundWorkerMeetingsInInterval)
                listOfMeetingBothOfWorkers.Add(meeting);

            var orderMeetings = listOfMeetingBothOfWorkers.OrderBy(m => m.Start);

            List<Meeting> meetings = new List<Meeting>();

            foreach (var meeting in orderMeetings)
            {
                meetings.Add(meeting);
            }

            List<Meeting> workersMeetings = SetBusyTime(meetings);

            Worker worker = new Worker
            {
                WorkingHours = interval,
                Meetings = workersMeetings
            };

            
            if (worker.Meetings[0].Start.CompareTo(interval.Start) < 0)
                worker.Meetings[0].Start = interval.Start;

            List<Meeting> resultList = new List<Meeting>();

            //11.04.2021 10:00:00 

            //11.04.2021 10:00:00 || 11.04.2021 10:30:00
            //11.04.2021 10:30:00 || 11.04.2021 11:30:00
            //11.04.2021 12:00:00 || 11.04.2021 13:00:00
            //11.04.2021 13:00:00 || 11.04.2021 14:30:00
            //11.04.2021 14:30:00 || 11.04.2021 15:00:00
            //11.04.2021 16:00:00 || 11.04.2021 18:00:00

            //11.04.2021 18:30:00 

            for (int i = 0; i < worker.Meetings.Count; i++)
            {
                if (i == worker.Meetings.Count - 1)
                    break;

                if (!(worker.Meetings[i].End.CompareTo(worker.Meetings[i + 1].Start) >= 0))
                    resultList.Add(new Meeting(worker.Meetings[i].End, worker.Meetings[i + 1].Start));
            }
            if (worker.Meetings[worker.Meetings.Count - 1].End.CompareTo(worker.WorkingHours.End) < 0)
                resultList.Add(new Meeting(worker.Meetings[worker.Meetings.Count - 1].End, worker.WorkingHours.End));

            return resultList;
        }
        private Worker CreatAbstractWorker(Worker firstWorker, Worker secoundWorker)
        {
            return new Worker();
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
        private List<Meeting> SetBusyTime(List<Meeting> meetings)
        {
            //11.04.2021 09:30:00 || 11.04.2021 10:30:00
            //11.04.2021 10:00:00 || 11.04.2021 11:30:00
            //11.04.2021 12:00:00 || 11.04.2021 13:00:00
            //11.04.2021 12:30:00 || 11.04.2021 14:30:00
            //11.04.2021 14:30:00 || 11.04.2021 15:00:00
            //11.04.2021 16:00:00 || 11.04.2021 18:00:00
            //11.04.2021 16:00:00 || 11.04.2021 17:00:00

            int i = 0;
            foreach (var meeting in meetings)
            {
                if (meeting.End.CompareTo(meetings[i + 1].Start) > 0)
                {
                    meetings[i + 1].Start = meeting.End;
                }
                i++;
                if (i == meetings.Count - 1)
                    break;
            }

            var foundMeetings = meetings.Where(m => m.Start.CompareTo(m.End) > 0).ToList();

            foreach (var meeting in foundMeetings)
            {
                meetings.Remove(meeting);
            }


            return meetings;
        }
    }
}
