using OpenQA.Selenium;
using Project.src.framework;

namespace Project.src.pages;

public class Profile : AutomationBaseUI
{
    private IWebElement pageTitle;
    private IWebElement bandStatus;
    
    public Profile(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        pageTitle = myDriver.FindElement(By.XPath("//h1[@class='band_name']/a"));
        bandStatus = myDriver.FindElement(By.XPath("//dt[text()='Status:']/following-sibling::dd[1]"));
    }

    public string GetPageTitle()
    {
        return pageTitle.Text;
    }

    public string GetBandStatus()
    {
        return bandStatus.Text;
    }
}