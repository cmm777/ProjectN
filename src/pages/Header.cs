using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;

namespace Project.src.pages;

public class Header : AutomationBase
{
    private Dropdown entityDropdown;
    private Textbox searchBox;
    private Button submitButton;

    public Header(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    public void Init(IWebDriver myDriver)
    {
        entityDropdown = new Dropdown(myDriver, myDriver.FindElement(By.XPath(LHeader.entityDropdown)));
        searchBox = new Textbox(myDriver, myDriver.FindElement(By.XPath(LHeader.searchBox)));
        submitButton = new Button(myDriver, myDriver.FindElement(By.XPath(LHeader.submitButton)));
    }

    public Desambiguation Search(string entity, string name)
    {
        entityDropdown.SelectOption(entity);
        searchBox.SendKeys(name);
        submitButton.Click();
        return new Desambiguation(myDriver);
    }
}