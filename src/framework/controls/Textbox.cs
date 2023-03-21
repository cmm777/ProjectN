using OpenQA.Selenium;

namespace Project.src.framework.controls;

public class Textbox : BaseElement
{
    private IWebDriver _myDriver;
    private IWebElement _element;

    public Textbox(IWebDriver myDriver, IWebElement webElement) : base(webElement)
    {
        _element = webElement;
        _myDriver = myDriver;
    }
}