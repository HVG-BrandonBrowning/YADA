using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Rhino.Mocks;
using NUnit.Framework;
using YADA;

namespace UnitTests
{
    internal class TestEntity
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    [TestFixture]
    [Category("Basic_DataBase_Operations")]
    public class BasicDataBaseOperations
    {
        private static MockRepository MockRepository { get; set; }

        static BasicDataBaseOperations()
        {
            MockRepository = new MockRepository();
        }

        [Test]
        public void GetRecordReturnsAnEntity()
        {
            string sproc = "test";

            var supplier = new StubDataReader(25);
            var parser = new SimpleDataReader(supplier, sproc);

            List<dynamic> results1;
            long time1 = Time(() => { results1 = parser.Read().Multiple().ToList(); });

            var supplier2 = new StubDataReader(100);
            var parser2 = new SimpleDataReader(supplier2, sproc);

            List<dynamic> results2;
            long time2 = Time(() => { results2 = parser2.Read().Multiple().ToList(); });
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