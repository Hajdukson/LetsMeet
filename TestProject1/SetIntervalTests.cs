using LetsMeet.DataSetLogic;
using LetsMeet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class SetIntervalTests
    {
        [TestMethod]
        public void SetIntervalTest_1()
        {
            DataSetters dh = new DataSetters();

            var worker1 = new Worker
            {
                WorkingHours = new WorkingHours(DateTime.Parse("09:00"), DateTime.Parse("19:55")),
            };
            var worker2 = new Worker
            {
                WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
            };


            WorkingHours workinghours = dh.SetInterval(worker1, worker2);

            Assert.AreEqual(DateTime.Parse("10:00"), workinghours.Start);

            Assert.AreEqual(DateTime.Parse("18:30"), workinghours.End);
        }
        [TestMethod]
        public void SetIntervalTest_2()
        {
            DataSetters dh = new DataSetters();

            var worker1 = new Worker
            {
                WorkingHours = new WorkingHours(DateTime.Parse("11:00"), DateTime.Parse("19:55")),

            };
            var worker2 = new Worker
            {
                WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
            };


            WorkingHours workinghours = dh.SetInterval(worker1, worker2);

            Assert.AreEqual(DateTime.Parse("11:00"), workinghours.Start);

            Assert.AreEqual(DateTime.Parse("18:30"), workinghours.End);
        }
    }
}
