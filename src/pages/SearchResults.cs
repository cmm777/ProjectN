using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;

namespace Project.src.pages;

public class SearchResults : AutomationBase
{
    private Button firstProduct;

    public SearchResults(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        firstProduct = new Button(myDriver, BaseElement.WaitForElementClickable(myDriver, By.XPath(LSearchResults.firstProduct), TimeSpan.FromSeconds(10)));
    }

    public ProductDetails SelectFirstProduct()
    {
        firstProduct.Click();
        return new ProductDetails(myDriver);
    }

}