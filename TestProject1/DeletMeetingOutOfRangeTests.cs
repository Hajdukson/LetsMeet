using LetsMeet.DataSetLogic;
using LetsMeet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    //[TestClass]
    //public class DeletMeetingOutOfRangeTests
    //{
    //    [TestMethod]
    //    public void DeleteMeetingOutOfRangeTest_1()
    //    {
    //        DataSetters ds = new DataSetters();
    //        var worker = new Worker
    //        {
    //            Name = "Michał",
    //            WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
    //            Meetings = new List<Meeting>
    //            {
    //                new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30")),
    //                new Meeting(DateTime.Parse("12:30"), DateTime.Parse("14:30")),
    //                new Meeting(DateTime.Parse("14:30"), DateTime.Parse("15:00")),
    //                //
    //                new Meeting(DateTime.Parse("18:30"), DateTime.Parse("19:00"))
    //            }
    //        };

    //        var count = ds.DeletMeetingOutOfInterval(worker.Meetings, worker.WorkingHours).Count;

    //        Assert.AreEqual(3, count);
    //    }
    //    [TestMethod]
    //    public void DeleteMeetingOutOfRangeTest_2()
    //    {
    //        DataSetters ds = new DataSetters();
    //        var worker = new Worker
    //        {
    //            Name = "Michał",
    //            WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
    //            Meetings = new List<Meeting>
    //            {
    //                new Meeting(DateTime.Parse("8:50"), DateTime.Parse("9:30")),
    //                new Meeting(DateTime.Parse("9:30"), DateTime.Parse("10:00")),
    //                //
    //                new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30")),
    //                new Meeting(DateTime.Parse("12:30"), DateTime.Parse("14:30")),
    //                new Meeting(DateTime.Parse("14:30"), DateTime.Parse("15:00")),
    //                new Meeting(DateTime.Parse("18:00"), DateTime.Parse("19:30")),
    //                //
    //                new Meeting(DateTime.Parse("19:30"), DateTime.Parse("21:00"))
    //            }
    //        };

    //        var count = ds.DeletMeetingOutOfInterval(worker.Meetings, worker.WorkingHours).Count;

    //        Assert.AreEqual(4, count);
    //    }
    //}
}
