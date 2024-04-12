using OpenQA.Selenium;
using Project.src.framework.automation;
using Project.src.framework.controls;
using Project.src.pages.locators;
using AventStack.ExtentReports;

namespace Project.src.pages;

public class Cart : AutomationBase
{
    private Button checkoutButton;
    private Label subtotalLabel;
    private Label cartTotalLabel;
    
    public Cart(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        checkoutButton = new Button(myDriver, BaseElement.WaitForElementClickable(myDriver, By.XPath(LCart.checkoutButton), TimeSpan.FromSeconds(10)));
        subtotalLabel = new Label(myDriver, myDriver.FindElement(By.XPath(LCart.subtotalLabel)));
        cartTotalLabel = new Label(myDriver, myDriver.FindElement(By.XPath(LCart.cartTotalLabel)));
    }

    // Deletes the item based in the position in the grid
    public string DeleteItemByIndex(int index)
    {
        var deleteButton = myDriver.FindElement(By.XPath("(//span[@data-action='delete'])["+index+"]"));
        test.Log(Status.Info, deleteButton.Text);
        deleteButton.Click();
        var itemsInCart = subtotalLabel.Text;
        return itemsInCart;
    }

    public double GetItemTotal(int index)
    {
        var priceTag = myDriver.FindElement(By.XPath("(//div[@class='sc-badge-price-to-pay']//span)["+index+"]"));
        string[] tokens = priceTag.Text.Split(' ');
        string retVal = tokens[0];
        var priceTagD = Double.Parse(retVal);
        return priceTagD;
    }

    public double GetCartTotal()
    {
        string[] tokens = cartTotalLabel.Text.Split(' ');
        string retVal = tokens[0];
        var cartTotalD = Double.Parse(retVal);
        return cartTotalD;
    }

    public Header ContinueShopping()
    {
        return new Header(myDriver);
    }

    public Cart ModifyItemCount(int index, int newQuantity)
    {
        var cartQuantityDropdown = myDriver.FindElement(By.XPath("(//span[@data-a-class='quantity'])["+index+"]"));
        cartQuantityDropdown.Click();
        var path = myDriver.FindElement(By.XPath("(//li[contains(@aria-labelledby,'quantity')])["+(newQuantity+1)+"]"));
        path.Click();
        Thread.Sleep(1000);
        return new Cart(myDriver);
    }

}