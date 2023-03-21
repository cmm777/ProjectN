using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;

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
        entityDropdown = new Dropdown(myDriver.FindElement(By.XPath("//select[@name='type']")));
        searchBox = new Textbox(myDriver.FindElement(By.XPath("//input[@id='searchQueryBox']")));
        submitButton = new Button(myDriver.FindElement(By.XPath("//button[@type='submit']")));
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