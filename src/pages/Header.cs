using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;

namespace Project.src.pages;

public class Header : AutomationBase
{
    private Textbox searchTextbox;
    private Button searchButton;
    private Button cartButton;

    public Header(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        searchTextbox = new Textbox(myDriver, BaseElement.WaitForElementClickable(myDriver, By.XPath(LHeader.searchTextbox), TimeSpan.FromSeconds(10)));
        searchButton = new Button(myDriver, myDriver.FindElement(By.XPath(LHeader.searchButton)));
        cartButton = new Button(myDriver, myDriver.FindElement(By.XPath(LHeader.cartButton)));
    }

    public SearchResults SearchForProduct(String searchString)
    {
        searchTextbox.SendKeys(searchString);
        searchButton.Click();
        return new SearchResults(myDriver);
    }

    public Cart GoToCart()
    {
        cartButton.Click();
        return new Cart(myDriver);
    }
}