using Microsoft.CodeAnalysis;
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

    internal void SelectOption(string path, int index)
    {
        index=index-1;
        _element.Click();
        var option = _myDriver.FindElement(By.XPath(path+"["+(index+1)+"]"));
        option.Click();
    }
}