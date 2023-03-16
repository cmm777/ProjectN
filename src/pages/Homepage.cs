using OpenQA.Selenium;
using Project.src.framework;

namespace Project.src.pages;

public class Homepage : AutomationBaseUI
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