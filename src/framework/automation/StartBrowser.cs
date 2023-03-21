using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Project.src.framework.automation;

public class StartBrowser
{
    private IWebDriver driver;

    public IWebDriver StartSelectedBrowser(string browser)
    {
        switch (browser)
        {
            case "Chrome": driver = StartChrome();
            break;

            case "Edge": driver = StartEdge();
            break;
        }
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
}