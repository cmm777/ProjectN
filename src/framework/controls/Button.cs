using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Project.src.framework.controls;

public class Button : BaseElement
{
    public Button(IWebElement webElement) : base(webElement)
    {
    }
}