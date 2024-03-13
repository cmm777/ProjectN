using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;

namespace Project.src.pages;

public class Careers : AutomationBase
{

    private Button positionsAvailableButton;
    private Button contactUsButton;

    public Careers(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        positionsAvailableButton = new Button(myDriver, myDriver.FindElement(By.XPath(LCareers.positionsAvailableButton)));
        contactUsButton = new Button(myDriver, myDriver.FindElement(By.XPath(LCareers.contactUsButton)));
    }

    public void ShowAvailablePositions()
    {
        positionsAvailableButton.Click();
        contactUsButton.WaitUntilDisplayed();
    }

    public int SearchOpportunity(string[] keywords)
    {
        IList<IWebElement> positions = myDriver.FindElements(By.XPath("//a[@class='teamtailor-jobs__job-title']"));
        var index = -1;
        for(int i=0; i<positions.Count; i++)
        {
            for(int j=0; j<keywords.Length; j++)
            {
                if(positions[i].Text.Contains(keywords[j]))
                {
                    index = i;
                }
            }
        }
        return index;
    }
}