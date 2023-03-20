using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project.src.pages;
using NUnit.Framework;

namespace Project.src.framework.automation;

public class AutomationBaseUI : ReportGeneration
{
    protected IWebDriver myDriver;
    public Header header;
    public Homepage homepage;

    [SetUp]
    public void Setup()
    {
        base.Setup("UI");
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        myDriver = new ChromeDriver(options);
        myDriver.Navigate().GoToUrl("https://www.metal-archives.com/");
        header = new Header(myDriver);
        homepage = new Homepage(myDriver);
    }

    [OneTimeSetUp]
    public new void ExtentStart()
    {
        base.ExtentStart();
    }

    [TearDown]
    public new void TearDown()
    {
        base.TearDown();
        myDriver.Quit();
    }

    [OneTimeTearDown]
    public new void ExtentClose()
    {
        base.ExtentClose();
    }
}
