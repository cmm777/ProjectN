using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project.src.pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Project.src.framework.automation;

public class AutomationBaseUI
{
    protected IWebDriver myDriver;
    public Header header;
    public Homepage homepage;

    public static ExtentTest test;
    public static ExtentReports extent;

    [SetUp]
    public void Setup()
    {
        test = extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.Name);
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        myDriver = new ChromeDriver(options);
        myDriver.Navigate().GoToUrl("https://www.metal-archives.com/");
        header = new Header(myDriver);
        homepage = new Homepage(myDriver);
    }

    [OneTimeSetUp]
    public void ExtentStart()
    {
        string reportPath = @"C:\Users\cmm77\Repositorios C\Project\src\report\UI\Automation UI Report " + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html";
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
        myDriver.Quit();
    }

    [OneTimeTearDown]
    public void ExtentClose()
    {
        extent.Flush();
    }
}
