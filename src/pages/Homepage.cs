using OpenQA.Selenium;
using Project.src.framework.automation;

namespace Project.src.pages;

public class Homepage : AutomationBase
{
    public Homepage(IWebDriver driver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    public void Init(IWebDriver myDriver)
    {

    }
}