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

            Console.ReadKey();
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
