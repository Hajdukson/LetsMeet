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
            DataSetters dataSetter = new DataSetters();

            IList<Worker> workers = PopulateData();

            var interval = dataSetter.WhenWorkersCanMeetTogether(workers[0], workers[1]);



            ICollection<Meeting> meetings = SetPossibleMeetings();
            //DateTime dateTime = DateTime.MinValue;

            //for (int i= 0; i < 48; i ++)
            //{
            //    meetings.Add(new Meeting(dateTime, dateTime + TimeSpan.FromMinutes(30)));
            //    dateTime += TimeSpan.FromMinutes(30);
            //}

            //var check = meetings;

            //foreach (var meeting in meetings)
            //{
            //    Console.WriteLine();
            //}

            //Meeting meeting = new Meeting(DateTime.Parse("09:00"), DateTime.Parse("9:30"));

            Console.ReadKey();
        }
        static IList<Meeting> SetPossibleMeetings()
        {
            List<Meeting> posibleMeetings = new List<Meeting>();
            DateTime dateTime = DateTime.Today;

            for (int i = 0; i < 47; i++)
            {
                posibleMeetings.Add(
                    new Meeting(dateTime, dateTime += TimeSpan.FromMinutes(30)));
            }

            return posibleMeetings;
        }
        static List<Worker> PopulateData()
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
