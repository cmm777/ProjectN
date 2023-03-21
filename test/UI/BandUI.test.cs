using Project.src.framework.automation;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace Project.test.UI;

[TestFixture]
public class BandUITest : AutomationBase
{
    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifySearchPageTitle()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string expectedPageTitle = "Search results for \"Metallica\"";

        // test steps
        test.Log(Status.Info, "Step 1: Search for "+entityName);
        var desambiguation = header.Search(entityType, entityName);
        test.Log(Status.Info, "Step 2: Get the page title");
        string dTitle = desambiguation.GetPageTitle();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(dTitle, Is.EqualTo(expectedPageTitle), "Validate the page title is the expected one");
    }

    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifyBandProfileIsDisplayed()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string title = "Search results for \"Metallica\"";
        string expectedPageTitle = "Metallica";

        // test steps
        test.Log(Status.Info, "Step 1: Search for "+entityName);
        var desambiguation = header.Search(entityType, entityName);
        var profile = desambiguation.TransitionToProfile(title);
        test.Log(Status.Info, "Step 2: Get the page title");
        string pTitle = profile.GetPageTitle();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(pTitle, Is.EqualTo(expectedPageTitle), "Validate the page title is the expected one");
    }

    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifyBandStatus()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string title = "Search results for \"Metallica\"";
        string expectedEntityStatus = "Active";

        // test steps
        test.Log(Status.Info, "Step 1: Search for "+entityName);
        var desambiguation = header.Search(entityType, entityName);
        var profile = desambiguation.TransitionToProfile(title);
        test.Log(Status.Info, "Step 2: Get the band status");
        string pStatus = profile.GetBandStatus();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(pStatus, Is.EqualTo(expectedEntityStatus), "Validate the band status is \"Active\"");
    }
}