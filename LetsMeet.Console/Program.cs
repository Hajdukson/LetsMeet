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
            IList<Worker> workers = PopulateData();
            Execute(workers[0], workers[1], (converResult, workers) =>
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"{workers[i].Name} data\nWorking hours: [{workers[i].WorkingHours.Start.ToString("HH:mm")} - " +
                        $"{workers[i].WorkingHours.End.ToString("HH:mm")}]\nMeetings:"); 
                    foreach (var meeting in workers[i].Meetings)
                    {
                        Console.WriteLine($"[{meeting.Start.ToString("HH:mm")} - {meeting.End.ToString("HH:mm")}]");
                    }
                    Console.Write("\n");
                }
                string output = "";
                foreach (var item in converResult){output += item; output += ", ";}
                Console.WriteLine($"Workers can meet at: [{output.TrimEnd(new char[] { ',', ' ' })}]");
            });

            Console.ReadKey();
        }
        static void Execute(Worker firstWorker, Worker secoundWorker, Action<string[], IList<Worker>> converResult)
        {
            DataSetters dataSetter = new DataSetters();

            var creatAbstractWorker = dataSetter.CreatAbstractWorker(firstWorker, secoundWorker);
            var listOfMeetings = dataSetter.CreatListOfMeetingsForWorkers(creatAbstractWorker);

            string[] output = new string[listOfMeetings.Count];
            for (int i = 0; i < listOfMeetings.Count; i++)
            {
                output[i] = $"[{listOfMeetings[i].Start.ToString("HH:mm")} - {listOfMeetings[i].End.ToString("HH:mm")}]";
            }
            converResult.Invoke(output, PopulateData());
        }
        static IList<Worker> PopulateData()
        {
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

    }
}
