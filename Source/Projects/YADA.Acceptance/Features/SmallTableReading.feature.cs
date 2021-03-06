﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.17626
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace YADA.Acceptance.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Small table reading")]
    public partial class SmallTableReadingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SmallTableReading.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Small table reading", "  In order to read a records from a small table\r\n  As a developer\r\n  I want to us" +
                    "e YADA in the most simple way to read items out of the database and populate val" +
                    "ue objects", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
    testRunner.Given("I have a test database created");
#line 8
    testRunner.Given("I have small table created");
#line 9
    testRunner.Given("I have small table populated");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I want to read 1 row")]
        [NUnit.Framework.CategoryAttribute("database")]
        public virtual void IWantToRead1Row()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I want to read 1 row", new string[] {
                        "database"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 13
    testRunner.When("using a store procedure to read a record");
#line 14
    testRunner.Then("the operation should happen in less than 3 ms");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I want to read in 15 rows out of 1000")]
        [NUnit.Framework.CategoryAttribute("database")]
        public virtual void IWantToReadIn15RowsOutOf1000()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I want to read in 15 rows out of 1000", new string[] {
                        "database"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 18
    testRunner.Given("I have small table populated with 1000 rows");
#line 19
    testRunner.When("using a store procedure to read in 15 records");
#line 20
    testRunner.Then("the operation should happen in less than 3 ms");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I want to read in 150 rows out of 1000")]
        [NUnit.Framework.CategoryAttribute("database")]
        public virtual void IWantToReadIn150RowsOutOf1000()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I want to read in 150 rows out of 1000", new string[] {
                        "database"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 24
    testRunner.Given("I have small table populated with 1000 rows");
#line 25
    testRunner.When("using a store procedure to read in 150 records");
#line 26
    testRunner.Then("the operation should happen in less than 3 ms");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I want to read in 1500 rows out of 10000")]
        [NUnit.Framework.CategoryAttribute("database")]
        public virtual void IWantToReadIn1500RowsOutOf10000()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I want to read in 1500 rows out of 10000", new string[] {
                        "database"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 30
    testRunner.Given("I have small table populated with 10000 rows");
#line 31
    testRunner.When("using a store procedure to read in 1500 records");
#line 32
    testRunner.Then("the operation should happen in less than 16 ms");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
