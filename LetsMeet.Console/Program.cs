using LetsMeet.DataSetLogic;
using LetsMeet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsMeet
{
    public class Program
    {

        static void Main(string[] args)
        {
            IList<Worker> _workers = PopulateData2();
            Execute(_workers[0], _workers[1]);

            Console.ReadKey();
        }
        static void Execute(Worker firstWorker, Worker secoundWorker)
        {
            Console.WriteLine($"{firstWorker.Name}' s data");
            Console.WriteLine($"Working hours: [{firstWorker.WorkingHours.Start.ToString("HH:mm")} - {firstWorker.WorkingHours.End.ToString("HH:mm")}]");
            foreach (var meeting in firstWorker.Meetings)
                Console.WriteLine($"[{meeting.Start.ToString("HH:mm")} - {meeting.End.ToString("HH: mm")}]");

            Console.WriteLine();

            Console.WriteLine($"{secoundWorker.Name}' s data");
            Console.WriteLine($"Working hours: [{secoundWorker.WorkingHours.Start.ToString("HH:mm")} - {secoundWorker.WorkingHours.End.ToString("HH:mm")}]");
            foreach (var meeting in secoundWorker.Meetings)
                Console.WriteLine($"[{meeting.Start.ToString("HH:mm")} - {meeting.End.ToString("HH:mm")}]");
            DataSetters dataSetter = new DataSetters();

            var creatAbstractWorker = dataSetter.CreatAbstractWorker(firstWorker, secoundWorker);
            var listOfMeetings = dataSetter.CreatListOfMeetingsForWorkers(creatAbstractWorker);

            string output = "[";
            for (int i = 0; i < listOfMeetings.Count; i++)
                output += $"[{listOfMeetings[i].Start.ToString("HH:mm")} - {listOfMeetings[i].End.ToString("HH:mm")}], ";


            Console.WriteLine("\nWorkers can meet at: " + output.TrimEnd(new char[] {',', ' ' }) + "]");
        }
        static IList<Worker> PopulateData()
        {
            //Meeting meeting = new Meeting(30);
            return new List<Worker>
            {
                new Worker{
                    Name = "Wojtek",
                    WorkingHours = new WorkingHours(DateTime.Parse("09:00"), DateTime.Parse("19:55")),
                    Meetings = new List<Meeting>
                    {
                        new Meeting(DateTime.Parse("09:00"), DateTime.Parse("10:30")),
                        new Meeting(DateTime.Parse("12:00"), DateTime.Parse("13:00")),
                        new Meeting(DateTime.Parse("16:00"), DateTime.Parse("18:00"))
                    }
                },
                new Worker{
                    Name = "Michał",
                    WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
                    Meetings = new List<Meeting>
                    {
                        new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30")),
                        new Meeting(DateTime.Parse("12:30"), DateTime.Parse("14:30")),
                        new Meeting(DateTime.Parse("14:30"), DateTime.Parse("15:00")),
                        new Meeting(DateTime.Parse("16:00"), DateTime.Parse("17:00"))
                    }
                },
            };
        }
        static IList<Worker> PopulateData2()
        {
            //Meeting meeting = new Meeting(60);
            return new List<Worker> {
                new Worker
                {
                    Name = "Wojtek",
                    WorkingHours = new WorkingHours(DateTime.Parse("09:00"), DateTime.Parse("20:00")),
                    Meetings = new List<Meeting>
                        {
                            new Meeting(DateTime.Parse("09:00"), DateTime.Parse("10:30")),
                            new Meeting(DateTime.Parse("12:00"), DateTime.Parse("13:00")),
                            new Meeting(DateTime.Parse("16:00"), DateTime.Parse("18:00")),
                            new Meeting(DateTime.Parse("18:30"), DateTime.Parse("19:30"))
                        }
                },
                new Worker
                {
                    Name = "Michał",
                    WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("20:00")),
                    Meetings = new List<Meeting>
                    {
                        new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30")),
                        new Meeting(DateTime.Parse("12:30"), DateTime.Parse("14:30")),
                        new Meeting(DateTime.Parse("14:30"), DateTime.Parse("15:00")),
                        new Meeting(DateTime.Parse("16:00"), DateTime.Parse("17:00"))
                    }
                }
            };
        }
    }
}
