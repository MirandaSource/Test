using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Test.Drivers
{
    [Binding]
    public class QSExtentReporter
    {

        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(QSTestConstantes.URL_REPORT);
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFuture()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        [Obsolete]
        public void insertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {

                if (stepType.Equals(QSTestConstantes.GIVEN))
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals(QSTestConstantes.WHEN))
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals(QSTestConstantes.THEN))
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals(QSTestConstantes.AND))
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }

            else if (ScenarioContext.Current.TestError != null)
            {
                string base64 = convertImageto64(QSTestConstantes.URL_REPORT_SS + ScenarioContext.Current.ScenarioInfo.Title.Trim() + ".jpg");
                var media = MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64, ScenarioStepContext.Current.StepInfo.Text.Trim()).Build();
                if (stepType.Equals(QSTestConstantes.GIVEN))
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, media);
                else if (stepType.Equals(QSTestConstantes.WHEN))
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, media);
                else if (stepType.Equals(QSTestConstantes.THEN))
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, media);


            }
        }

        [BeforeScenario]
        [Obsolete]
        public void Initialize()
        {
            Thread.Sleep(4000);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        private string convertImageto64(string path)
        {
            return Convert.ToBase64String(File.ReadAllBytes(path));
        }

    }
}