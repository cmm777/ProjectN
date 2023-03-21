using OpenQA.Selenium;

namespace Project.src.framework.controls;

public class Dropdown : BaseElement
{
    private IWebDriver _myDriver;
    private IWebElement _element;

    public Dropdown(IWebDriver myDriver, IWebElement webElement) : base(webElement)
    {
        _element = webElement;
        _myDriver = myDriver;
    }

    internal void SelectOption(string entity)
    {
        _element.Click();
        var option = _myDriver.FindElement(By.XPath("//option[@value='"+entity+"']"));
        option.Click();
    }
}