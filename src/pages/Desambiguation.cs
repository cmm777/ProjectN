using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;

namespace Project.src.pages;

public class Desambiguation : AutomationBase
{
    private Label pageTitle;
    
    public Desambiguation(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        pageTitle = new Label(myDriver, myDriver.FindElement(By.XPath("//h1[@class='page_title']")));
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