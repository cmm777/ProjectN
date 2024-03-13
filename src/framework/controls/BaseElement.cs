using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using System.Threading;

namespace Project.src.framework.controls;

public class BaseElement : IWebElement
{
    private IWebElement _element;

    public BaseElement (IWebElement webElement)
    {
        _element = webElement;
    }

    public string TagName => _element.TagName;

    public string Text => _element.Text;

    public bool Enabled => _element.Enabled;

    public bool Selected => _element.Selected;

    public Point Location => _element.Location;

    public Size Size => _element.Size;

    public bool Displayed => _element.Displayed;

    public void Clear()
    {
        _element.Clear();
    }

    public void Click()
    {
        _element.Click();
    }

    public IWebElement FindElement(By by)
    {
        return _element.FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _element.FindElements(by);
    }

    public string GetAttribute(string attributeName)
    {
        return _element.GetAttribute(attributeName);
    }

    public string GetCssValue(string propertyName)
    {
        return _element.GetCssValue(propertyName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _element.GetDomAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _element.GetDomProperty(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _element.GetShadowRoot();
    }

    public void SendKeys(string text)
    {
        _element.SendKeys(text);
    }

    public void Submit()
    {
        _element.Submit();
    }

    //This method should be refactored to also prevent NoSuchElement exceptions
    public void WaitUntilDisplayed()
    {
        var threshold = 5000;
        var elapsed = 0;
        while(_element.Displayed == false && elapsed < threshold)
        {
            Thread.Sleep(500);
            elapsed = elapsed + 500;
        }
        if(_element.Displayed == false)
        {
            throw new ElementNotVisibleException("Element wasn't found after 5 seconds");
        }
    }
}