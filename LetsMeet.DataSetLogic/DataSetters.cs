using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsMeet.DataSetLogic
{
    /// <summary>
    /// This class is responsible for the logic
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class DataSetters
    {
        /// <param name="abstractWorker">Takes abstract worker whitch you can creat using CreatAbstractWorker function</param>
        /// <returns>The finel result</returns>
        public IList<Meeting> CreatListOfMeetingsForWorkers(Worker abstractWorker)
        {
            IList<Meeting> resultList = new List<Meeting>();
            for (int i = 0; i < abstractWorker.Meetings.Count; i++)
            {
                if (i == abstractWorker.Meetings.Count - 1)
                    break;

                if (!(abstractWorker.Meetings[i].End.CompareTo(abstractWorker.Meetings[i + 1].Start) >= 0) && 
                    Meeting.Duration <= (abstractWorker.Meetings[i + 1].Start - abstractWorker.Meetings[i].End))
                    resultList.Add(new Meeting(abstractWorker.Meetings[i].End, abstractWorker.Meetings[i + 1].Start));
            }
            if ((abstractWorker.Meetings[abstractWorker.Meetings.Count - 1].End.CompareTo(abstractWorker.WorkingHours.End) < 0)
                && Meeting.Duration <= (abstractWorker.WorkingHours.End - abstractWorker.Meetings[abstractWorker.Meetings.Count - 1].End))
                resultList.Add(new Meeting(abstractWorker.Meetings[abstractWorker.Meetings.Count - 1].End, abstractWorker.WorkingHours.End));

            return resultList;
        }
        /// <summary>
        /// Creats the abstract worker who holds two lists of meetings of both workers
        /// </summary>
        /// <param name="firstworker">The first input value</param>
        /// <param name="secoundworker">The secound input value</param>
        /// <returns>The not existing worker</returns>
        public Worker CreatAbstractWorker(Worker firstworker, Worker secoundworker)
        {
            IList<Meeting> firstWorkerMeetings = firstworker.Meetings;
            IList<Meeting> secoundWorkerMeetings = secoundworker.Meetings;

            WorkingHours interval = SetInterval(firstworker, secoundworker);

            ICollection<Meeting> firstWorkerMeetingsInInterval = DeletMeetingOutOfInterval(firstWorkerMeetings, interval);
            ICollection<Meeting> secoundWorkerMeetingsInInterval = DeletMeetingOutOfInterval(secoundWorkerMeetings, interval);

            //the following lines create a common list which holds meetings of the first and the secound worker 
            IList<Meeting> listOfMeetingsBothOfWorkers = new List<Meeting>();

            foreach (var meeting in firstWorkerMeetingsInInterval)
                listOfMeetingsBothOfWorkers.Add(meeting);
            foreach (var meeting in secoundWorkerMeetingsInInterval)
                listOfMeetingsBothOfWorkers.Add(meeting);

            var orderMeetings = listOfMeetingsBothOfWorkers.OrderBy(m => m.Start);

            IList<Meeting> meetings = new List<Meeting>();
            foreach (var meeting in orderMeetings)
            {
                meetings.Add(meeting);
            }

            //The list before a fixing:
            //11.04.2021 09:30:00 || 11.04.2021 10:30:00
            //11.04.2021 10:00:00 || 11.04.2021 11:30:00
            //11.04.2021 12:00:00 || 11.04.2021 13:00:00
            //11.04.2021 12:30:00 || 11.04.2021 14:30:00
            //11.04.2021 14:30:00 || 11.04.2021 15:00:00
            //11.04.2021 16:00:00 || 11.04.2021 18:00:00
            //11.04.2021 16:00:00 || 11.04.2021 17:00:00

            IList<Meeting> workersMeetings = FixListOfMeetings(meetings);

            Worker worker = new Worker
            {
                WorkingHours = interval,
                Meetings = workersMeetings
            };
            if (worker.Meetings[0].Start.CompareTo(interval.Start) < 0)
                worker.Meetings[0].Start = interval.Start;

            //11.04.2021 10:00:00 

            //11.04.2021 10:00:00 || 11.04.2021 10:30:00
            //11.04.2021 10:30:00 || 11.04.2021 11:30:00
            //11.04.2021 12:00:00 || 11.04.2021 13:00:00
            //11.04.2021 13:00:00 || 11.04.2021 14:30:00
            //11.04.2021 14:30:00 || 11.04.2021 15:00:00
            //11.04.2021 16:00:00 || 11.04.2021 18:00:00

            //11.04.2021 18:30:00 

            return worker;
        }
        /// <summary>
        /// Sets a common interval for both workers
        /// </summary>
        /// <param name="firstworker"></param>
        /// <param name="secoundworker"></param>
        /// <returns></returns>
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
        private IList<Meeting> FixListOfMeetings(IList<Meeting> meetings)
        {
            int i = 0;
            foreach (var meeting in meetings)
            {
                if (meeting.End.CompareTo(meetings[i + 1].Start) > 0)
                    meetings[i + 1].Start = meeting.End;

                i++;

                if (i == meetings.Count - 1)
                    break;
            }

            //Delete not valid meetings: when the start is leater than the end of the meeting
            var foundMeetings = meetings.Where(m => m.Start.CompareTo(m.End) > 0).ToList();
            foreach (var meeting in foundMeetings)
                meetings.Remove(meeting);

            return meetings;
        }
    }
}
