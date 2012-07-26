using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using YADA;
using YADA.Acceptance.Extensions;
using YADA.Acceptance.StepDefinitions.Values;
using YADA.Simple;

namespace YADA.Acceptance.StepDefinitions
{
    [Binding]
    internal class SmallTableReading : BaseRunner
    {
        private IList<int> _executionTimes;
        private Database Database { get; set; }
        private TimeSpan ExecutionTime { get; set; }

        private IList<int> ExecutionTimes
        {
            get { return _executionTimes ?? (_executionTimes = new List<int>()); }
            set { _executionTimes = value; }
        }

        public double AverageExecutionTime
        {
            get { return ExecutionTimes.Average(); }
        }

        private int NumberOfInsertedRows { get; set; }

        private SmallTableReading()
        {
            Database = new Database("Data Source=(local);Initial Catalog=AdventureWorks2012;Integrated Security=SSPI;");
        }

        [AfterScenario("database")]
        public void CleanUp()
        {
            RunScriptAgainistDatabase(@"Scripts\RemoveYadaTestDB.sql");
        }

        [Given(@"I have a test database created")]
        public void GivenIHaveATestDatabaseCreated()
        {
            RunScriptAgainistDatabase(@"Scripts\CreateYadaTestDB.sql");
        }

        [Given(@"I have small table created")]
        public void GivenIHaveSmallTableCreated()
        {
            // Done in previous step
        }

        [Given(@"I have small table populated")]
        public void GivenIHaveSmallTablePopulated()
        {
            RunScriptAgainistDatabase(@"Scripts\InsertData.sql");
        }

        [Given(@"I have small table populated with (.*) rows")]
        public void GivenIHaveSmallTablePopulatedWithRows(int numberOfRows)
        {
            NumberOfInsertedRows = numberOfRows;

            for (var i = 0; i < numberOfRows; i++)
            {
                var paramters = new[]
                {
                    new SqlParameter("TestValue1", StringExtensions.GetRandomString(47)), 
                    new SqlParameter("TestValue2", StringExtensions.GetRandomString(247))
                };

                Database.ExecuteProcedure("[YadaTesting].[dbo].[CreateSmallDataRow]", paramters);
            }

            NumberOfInsertedRows = numberOfRows;
        }

        [Then(@"the operation should happen in less than (.*) ms")]
        public void ThenTheOperationShouldHappenInLessThanMS(int milliseconds)
        {
            AverageExecutionTime.Should().BeLessThan(milliseconds);
        }

        [When(@"using a store procedure to read a record")]
        public void WhenUsingAStoreProcedureToReadARecord()
        {
            for (var i = 0; i < 100; i++)
            {
                var stopWatch = Stopwatch.StartNew();

                var keyID = (i % 2) + 1;

                var item = Database.ExecuteProcedure("YadaTesting.dbo.GetNarrowSmallDataByID", new[] { new SqlParameter("SmallDataID", keyID), }).First();

                stopWatch.Stop();

                ExecutionTime = stopWatch.Elapsed;

                ExecutionTimes.Add(ExecutionTime.Milliseconds);

                switch (keyID)
                {
                    case 1:
                        item.TableKey.Should().Be(1);
                        item.TestValue1.Should().Be("WhatIsOurTopic");
                        item.TestValue2.Should().Be("RellectionAndTheBartletPyshcos");
                        item.DateAdded.Should().BeBefore(DateTime.Now);
                        item.DateAdded.Should().BeAfter(DateTime.Now.AddDays(-1));
                        break;
                    case 2:
                        item.TableKey.Should().Be(2);
                        item.TestValue1.Should().Be("FoldedPieceOfPaper");
                        item.TestValue2.Should().Be("They are Teaching Us something about ourselves");
                        item.DateAdded.Should().BeBefore(DateTime.Now);
                        item.DateAdded.Should().BeAfter(DateTime.Now.AddDays(-1));
                        break;
                    default:
                        item.TableKey.Should().Be(3);
                        item.TestValue1.Should().Be("DropOff");
                        item.TestValue2.Should().Be("What time do you want to drop off the kids?");
                        item.DateAdded.Should().BeBefore(DateTime.Now);
                        item.DateAdded.Should().BeAfter(DateTime.Now.AddDays(-1));
                        break;
                }
            }

            Console.WriteLine("Average Read Time for read {0} MS", AverageExecutionTime);
        }

        [When(@"using a store procedure to read in (.*) records")]
        public void WhenUsingAStoreProcedureToReadInRecords(int numberOfRecords)
        {
            for (var i = 0; i < 50; i++)
            {
                var startRecordID = NumberExtensions.NextRandom(1, NumberOfInsertedRows - numberOfRecords - 1);

                var parameters = new[]
                    {
                        new SqlParameter("MinRecordID", startRecordID),
                        new SqlParameter("MaxRecordID", startRecordID + numberOfRecords - 1)
                    };

                var stopwatch = Stopwatch.StartNew();

                var items = Database.ExecuteProcedure("[YadaTesting].[dbo].[GetRangeOfRecords]", parameters);

                stopwatch.Stop();

                ExecutionTime = stopwatch.Elapsed;

                ExecutionTimes.Add(ExecutionTime.Milliseconds);

                items.Count.Should().Be(numberOfRecords);
            }

            Console.WriteLine("Average Read Time for read {0} MS", AverageExecutionTime);
        }
    }
}