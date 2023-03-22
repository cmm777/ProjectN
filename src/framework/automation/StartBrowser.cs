using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Project.src.framework.automation;

public class StartBrowser
{
    private IWebDriver driver;

    public IWebDriver StartSelectedBrowser(Browsers browser, string environment)
    {
        switch (browser)
        {
            case Browsers.Chrome : driver = StartChrome();
            break;

            case Browsers.Edge : driver = StartEdge();
            break;

            case Browsers.Firefox : driver = StartFirefox();
            break;

            default : driver = StartChrome();
            break;
        }
        driver.Navigate().GoToUrl(environment);
        return driver;
    }

    public IWebDriver StartChrome()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        return driver = new ChromeDriver(options);
    }

    public IWebDriver StartEdge()
    {
        EdgeOptions options = new EdgeOptions();
        options.AddArgument("start-maximized");
        return driver = new EdgeDriver(options);
    }

        public IWebDriver StartFirefox()
    {
        FirefoxOptions options = new FirefoxOptions();
        options.AddArgument("start-maximized");
        return driver = new FirefoxDriver(options);
    }
}