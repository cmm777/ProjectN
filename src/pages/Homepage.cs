using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;

namespace Project.src.pages;

public class Homepage : AutomationBase
{
    
    public Homepage(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        
    }
}