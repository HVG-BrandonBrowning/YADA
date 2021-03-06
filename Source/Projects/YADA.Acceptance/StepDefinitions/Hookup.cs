﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace YADA.Acceptance.StepDefinitions
{
    [Binding]
    internal class Hookup : BaseRunner
    {
        private bool Connected { get; set; }
        
        private bool Created { get; set; }
        private bool Deleted { get; set; }

        [Given(@"I have a connection string configured")]
        public void GivenIHaveAConnectionStringConfigured()
        {
            ConfigurationManager.ConnectionStrings.Count.Should().BeGreaterThan(0);
        }

        [Then(@"I can connect to the database")]
        public void ThenICanConnectToTheDatabase()
        {
            Connected.Should().BeTrue();
        }

        [Then(@"I can create the database")]
        public void ThenICanCreateTheDatabase()
        {
            Created.Should().BeTrue();
        }

        [Then(@"I can delete the database")]
        public void ThenICanDeleteTheDatabase()
        {
            Deleted.Should().BeTrue();
        }

        [When(@"I attempt to connect to the database")]
        public void WhenIAttemptToConnectToTheDatabase()
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);

                connection.Open();
                connection.Close();
                connection.Dispose();

                Connected = true;
            }
            catch (Exception)
            {
                Connected = false;
            }
        }

        [When(@"I attempt to create a database")]
        public void WhenIAttemptToCreateADatabase()
        {
            try
            {
                RunScriptAgainistDatabase(@"Scripts\CreateTest.sql");

                Created = true;
            }
            catch
            {
                Created = false;

                throw;
            }
        }

        [When(@"I attempt to delete a database")]
        public void WhenIAttemptToDeleteADatabase()
        {
            try
            {
                RunScriptAgainistDatabase(@"Scripts\RemoveTest.sql");

                Deleted = true;
            }
            catch
            {
                Deleted = false;

                throw;
            }
        }
    }
}