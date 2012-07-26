using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;
using YADA;
using YADA.Simple;

namespace UnitTests
{
    [TestFixture]
    [Category("Basic_DataBase_Operations")]
    public class BasicDataBaseOperations
    {
        private static Database Database { get; set; }
        private static MockRepository MockRepository { get; set; }

        static BasicDataBaseOperations()
        {
            Database = new Database("Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=SSPI;");
            MockRepository = new MockRepository();
        }

        [Test]
        // [Ignore("Is more of an acceptence test")]
        public void GettingRecordsFromTheLocalAdventureworksDatabaseIsFasterAfterTheFirst()
        {
            long firstRun = Time(() => Database.LoadFromStoredProcedure("[dbo].[uspGetEmployeeManagers]", new SqlParameter[] { new SqlParameter("@EmployeeID", 5) }));
            long secondRun = Time(() => Database.LoadFromStoredProcedure("[dbo].[uspGetEmployeeManagers]", new SqlParameter[] { new SqlParameter("@EmployeeID", 5) }));

            Assert.IsTrue(firstRun > (secondRun * 2));
        }

        [Test]
        // [Ignore("Is more of an acceptence test")]
        public void GettingRecordsFromTheLocalAdventureworksDatabaseIsUnder30msTheSecondTime()
        {
            long firstRun = Time(() => Database.LoadFromStoredProcedure("[dbo].[uspGetEmployeeManagers]", new SqlParameter[] { new SqlParameter("@EmployeeID", 5) }));
            long secondRun = Time(() => Database.LoadFromStoredProcedure("[dbo].[uspGetEmployeeManagers]", new SqlParameter[] { new SqlParameter("@EmployeeID", 5) }));

            Assert.That(secondRun < 30);
        }

        private static long Time(Action action)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();

            action();

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }
    }
}