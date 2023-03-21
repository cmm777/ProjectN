using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;

namespace Project.src.pages;

public class Homepage : AutomationBase
{
    public Homepage(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    public void Init(IWebDriver myDriver)
    {

    }
}