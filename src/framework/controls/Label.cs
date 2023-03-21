using OpenQA.Selenium;

namespace Project.src.framework.controls;

public class Label : BaseElement
{
    private IWebDriver _myDriver;
    private IWebElement _element;

    public Label(IWebDriver myDriver, IWebElement webElement) : base(webElement)
    {
        _element = webElement;
        _myDriver = myDriver;
    }
}