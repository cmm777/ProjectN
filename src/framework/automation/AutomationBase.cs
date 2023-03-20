using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project.src.pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Project.src.framework.automation;

public class AutomationBase
{
    protected IWebDriver myDriver;
    public Header header;
    public Homepage homepage;
    public static ExtentTest test;
    public static ExtentReports extent = new ExtentReports();

    string varControl1;
    string varControl2;
    string varControl3;


    [OneTimeSetUp]
    public void ExtentStart()
    {
        string reportPath = @"C:\Users\cmm77\Repositorios C\Project\src\report\";
        ExtentLoggerReporter logger = new ExtentLoggerReporter(reportPath);
        if(TestContext.CurrentContext.Test.Properties["Category"].Contains("UI"))
        {
            logger.Config.ReportName = "UI Report";
        }
        else
        {
            logger.Config.ReportName = "API Report";
        }

        extent.AttachReporter(logger);
    }

    [SetUp]
    public void Setup()
    {
        test = extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.Name);
        if(TestContext.CurrentContext.Test.Properties["Category"].Contains("UI"))
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            myDriver = new ChromeDriver(options);
            myDriver.Navigate().GoToUrl("https://www.metal-archives.com/");
            header = new Header(myDriver);
            homepage = new Homepage(myDriver);
        }
    }

    [TearDown]
    public void TearDown()
    {
        var result = TestContext.CurrentContext.Result.Outcome.ToString();
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
        if(TestContext.CurrentContext.Test.Properties["Category"].Contains("UI"))
        {
            myDriver.Quit();
        }
    }

    [OneTimeTearDown]
    public void ExtentClose()
    {
        extent.Flush();
    }
}
