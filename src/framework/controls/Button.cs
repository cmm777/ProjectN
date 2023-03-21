using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Project.src.framework.controls;

public class Button : BaseElement
{
    private IWebDriver _myDriver;
    private IWebElement _element;

    public Button(IWebDriver myDriver, IWebElement webElement) : base(webElement)
    {
        _element = webElement;
        _myDriver = myDriver;
    }
}