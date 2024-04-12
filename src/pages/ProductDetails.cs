using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;

namespace Project.src.pages;

public class ProductDetails : AutomationBase
{
    private Button addToCartButton;
    private Dropdown quantityDropdown;
    private Label unitPriceLabelWhole;
    private Label unitPriceLabelFraction;

    public ProductDetails(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        quantityDropdown = new Dropdown(myDriver, BaseElement.WaitForElementClickable(myDriver, By.XPath(LProductDetails.quantityDropdown), TimeSpan.FromSeconds(10)));
        addToCartButton = new Button(myDriver, myDriver.FindElement(By.XPath(LProductDetails.addToCartButton)));
        unitPriceLabelWhole = new Label(myDriver, myDriver.FindElement(By.XPath(LProductDetails.unitPriceLabelWhole)));
        unitPriceLabelFraction = new Label(myDriver, myDriver.FindElement(By.XPath(LProductDetails.unitPriceLabelFraction)));
    }

    public Header AddToCart(int quantity)
    {
        var path = "(//li[contains(@aria-labelledby,'quantity')])";
        if(quantity>1)
        {
            quantityDropdown.SelectOption(path, quantity);
        }
        addToCartButton.Click();
        return new Header(myDriver);
    }

    public double GetUnitPrice()
    {
        var unitPrice = unitPriceLabelWhole.Text+","+unitPriceLabelFraction.Text;
        var unitPriceD = Double.Parse(unitPrice);
        return unitPriceD;
    }

}