using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project.src.pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Project.src.framework;

public class AutomationBaseAPI
{
    public static ExtentTest test;
    public static ExtentReports extent;

    [SetUp]
    public void Setup()
    {
        test = extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.Name);
    }

    [OneTimeSetUp]
    public void ExtentStart()
    {
        string reportPath = @"C:\Users\cmm77\Repositorios C\Project\src\report\API\Automation API Report " + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html";
        var htmlreporter = new ExtentHtmlReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlreporter);
    }

    [TearDown]
    public void TearDown()
    {
        var result = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.ToString();
        switch (result)
        {
            case "Inconclusive":
            test.Log(Status.Warning, "Inconclusive");
            break;

            case "Skipped":
            test.Log(Status.Skip, "Skipped");
            break;

            case "Passed":
            test.Log(Status.Pass, "Passed");
            break;

            case "Failed":
            test.Log(Status.Fail, "Failed");
            break;

            default:
            test.Log(Status.Info, "There was a problem while running the test case");
            break;
        }
    }
    
    [OneTimeTearDown]
    public void ExtentClose()
    {
        extent.Flush();
    }
}
