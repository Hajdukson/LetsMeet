using LetsMeet.DataSetLogic;
using LetsMeet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class CanSetMeetingTests
    {
        [TestMethod]
        public void CanAddMeetingTest_False_1()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("6:30"), DateTime.Parse("10:30"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(false, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_False_2()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("19:30"), DateTime.Parse("20:00"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(false, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_False_3()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("11:30"), DateTime.Parse("13:00"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(false, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_True_1()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("16:00"), DateTime.Parse("16:30"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_True_2()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("12:00"), DateTime.Parse("16:30"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_True_3()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("12:00"), DateTime.Parse("16:30"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_True_4()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("11:00"), DateTime.Parse("11:30"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void CanAddMeetingTest_True_5()
        {
            DataSetters dh = new DataSetters();
            var worker = new Worker();
            worker.WorkingHours = new WorkingHours(DateTime.Parse("7:30"),
                                       DateTime.Parse("19:30"));

            worker.Meetings = new List<Meeting>
            {
                 new Meeting(DateTime.Parse("7:30"), DateTime.Parse("10:30")),
                 new Meeting(DateTime.Parse("11:30"), DateTime.Parse("12:00")),
                 new Meeting(DateTime.Parse("16:30"), DateTime.Parse("17:00")),
            };

            var meeting = new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30"));

            var test = dh.CanAddMeeting(worker, meeting);

            Assert.AreEqual(true, test);
        }

    }
}
