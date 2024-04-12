using Project.src.framework.automation;
using NUnit.Framework;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;

namespace Project.test.UI;

[TestFixture]
public class CartTests : AutomationBase
{
    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void TC99()
    {
        var searchString1 = "caps for men";
        var searchString2 = "shoes for women";
        var item1Q = 2;
        var item2Q = 1;
        var newItem1Q = 1;

        var searchResults = header.SearchForProduct(searchString1);
        var productDetails = searchResults.SelectFirstProduct();
        var unitPrice1 = productDetails.GetUnitPrice();
        header = productDetails.AddToCart(item1Q);
        var cart = header.GoToCart();
        var itemTotal1 = cart.GetItemTotal(1);
        var cartTotal1 = cart.GetCartTotal();
        header = cart.ContinueShopping();
        searchResults = header.SearchForProduct(searchString2);
        productDetails = searchResults.SelectFirstProduct();
        var unitPrice2 = productDetails.GetUnitPrice();
        header = productDetails.AddToCart(item2Q);
        cart = header.GoToCart();
        var itemTotal2 = cart.GetItemTotal(1);
        var cartTotal2 = cart.GetCartTotal();
        cart = cart.ModifyItemCount(2, newItem1Q);
        var cartTotal3 = cart.GetCartTotal();
        header = cart.ContinueShopping();
    
        Assert.That(itemTotal1, Is.EqualTo(unitPrice1), "Checking item 1 price in ProductDetails vs Cart");
        Assert.That(cartTotal1, Is.EqualTo(unitPrice1*item1Q), "Checking cart total against the item price times quantity");
        Assert.That(itemTotal2, Is.EqualTo(unitPrice2), "Checking item 2 price in ProductDetails vs Cart");
        Assert.That(cartTotal2, Is.EqualTo((unitPrice1*item1Q)+(unitPrice2*item2Q)), "Checking cart total against the 2 items price times quantity for each one");
        Assert.That(cartTotal3, Is.EqualTo((unitPrice1*newItem1Q)+(unitPrice2*item2Q)), "Checking cart total against the 2 items price times quantity for each one");
    }
}