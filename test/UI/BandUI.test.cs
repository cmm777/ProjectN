using Project.src.framework.automation;
using NUnit.Framework;

namespace Project.test.UI;

[TestFixture]
public class BandUITest : AutomationBaseUI
{
    [Test]
    public void VerifySearchPageTitle()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string expectedPageTitle = "Search results for \"Metallica\"";

        // test steps
        var desambiguation = header.Search(entityType, entityName);
        string dTitle = desambiguation.GetPageTitle();
        Assert.That(dTitle, Is.EqualTo(expectedPageTitle), "Validate the page title is the expected one");
    }

    [Test]
    public void VerifyBandProfileIsDisplayed()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string title = "Search results for \"Metallica\"";
        string expectedPageTitle = "Metallica";

        // test steps
        var desambiguation = header.Search(entityType, entityName);
        var profile = desambiguation.TransitionToProfile(title);
        string pTitle = profile.GetPageTitle();
        Assert.That(pTitle, Is.EqualTo(expectedPageTitle), "Validate the page title is the expected one");
    }

    [Test]
    public void VerifyBandStatus()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string title = "Search results for \"Metallica\"";
        string expectedEntityStatus = "Active";

        // test steps
        var desambiguation = header.Search(entityType, entityName);
        var profile = desambiguation.TransitionToProfile(title);
        string pStatus = profile.GetBandStatus();
        Assert.That(pStatus, Is.EqualTo(expectedEntityStatus), "Validate the band status is \"Active\"");
    }
}