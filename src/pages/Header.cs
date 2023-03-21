using OpenQA.Selenium;
using Project.src.framework.automation;

namespace Project.src.pages;

public class Header : AutomationBase
{
    private IWebElement entityDropdown;
    private IWebElement searchBox;
    public IWebElement submitButton;

    public Header(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    public void Init(IWebDriver myDriver)
    {
        entityDropdown = myDriver.FindElement(By.XPath("//select[@name='type']"));
        searchBox = myDriver.FindElement(By.XPath("//input[@id='searchQueryBox']"));
        submitButton = myDriver.FindElement(By.XPath("//button[@type='submit']"));
    }

    public Desambiguation Search(string entity, string name)
    {
        entityDropdown.Click();
        var option = myDriver.FindElement(By.XPath("//option[@value='"+entity+"']"));
        option.Click();
        searchBox.SendKeys(name);
        submitButton.Click();
        return new Desambiguation(myDriver);
    }
}