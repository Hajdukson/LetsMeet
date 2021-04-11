using LetsMeet;
using LetsMeet.DataSetLogic;
using LetsMeet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class CanMeetTogetherTests
    {
        [TestMethod]
        public void CanMeetTogetherTest_1()
        {
            DataSetters ds = new DataSetters();

            Worker firstWorker = new Worker
            {
                Name = "Wojtek",
                WorkingHours = new WorkingHours(DateTime.Parse("09:00"), DateTime.Parse("19:55")),
                Meetings = new List<Meeting>
                    {
                        new Meeting(DateTime.Parse("09:00"), DateTime.Parse("10:30")),
                        new Meeting(DateTime.Parse("12:00"), DateTime.Parse("13:00")),
                        new Meeting(DateTime.Parse("16:00"), DateTime.Parse("18:00"))
                    }
            };
            Worker secoundWorker = new Worker
            {
                Name = "Michał",
                WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
                Meetings = new List<Meeting>
                {
                    new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30")),
                    new Meeting(DateTime.Parse("12:30"), DateTime.Parse("14:30")),
                    new Meeting(DateTime.Parse("14:30"), DateTime.Parse("15:00")),
                    new Meeting(DateTime.Parse("16:00"), DateTime.Parse("17:00"))
                }
            };

            var actualMeetings = ds.WhenWorkersCanMeetTogether(firstWorker, secoundWorker);

            //[["11:30","12:00"], ["15:00", "16:00"], ["18:00", "18:30"]]
            List<Meeting> expectedMeetings = new List<Meeting>
            {
                new Meeting(DateTime.Parse("11:30"),  DateTime.Parse("12:00")),
                new Meeting(DateTime.Parse("15:00"), DateTime.Parse("16:00")),
                new Meeting(DateTime.Parse("18:00"), DateTime.Parse("18:30"))
            };

            if (actualMeetings.Count == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Assert.AreEqual(expectedMeetings[i].Start, actualMeetings[i].Start);
                    Assert.AreEqual(expectedMeetings[i].End, actualMeetings[i].End);
                }
            }
            else
                throw new AssertFailedException("lists have a different number of objects");
        }
    }
}
