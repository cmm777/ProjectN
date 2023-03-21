using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Project.src.framework.controls;

public class Textbox : BaseElement
{
    public Textbox(IWebElement webElement) : base(webElement)
    {
    }
}