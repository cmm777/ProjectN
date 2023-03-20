using OpenQA.Selenium;
using Project.src.framework.automation;

namespace Project.src.pages;

public class Desambiguation : AutomationBase
{
    private IWebElement pageTitle;
    
    public Desambiguation(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        pageTitle = myDriver.FindElement(By.XPath("//h1[@class='page_title']"));
    }

    public string GetPageTitle()
    {
        return pageTitle.Text;
    }

    public Profile TransitionToProfile(string title)
    {
        try
        {
            while(pageTitle.Displayed == true)
            {

            }
        }
        catch
        {
        }
        return new Profile(myDriver);
    }
}