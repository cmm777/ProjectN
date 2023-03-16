using Project.src.framework;
using NUnit.Framework;

namespace Project.test.UI;

[TestFixture]
public class BandUITest : AutomationBaseUI
{
    [Test]
    public void VerifySearchPageTitle()
    {
        // test variables
        string entity = "band_name";
        string name = "Metallica";

        // test steps
        var desambiguation = header.Search(entity, name);
        string dTitle = desambiguation.GetPageTitle();

        Assert.AreEqual(dTitle, "Search results for \"Metallica\"", "Validate the page title is the expected one");
    }

    [Test]
    public void VerifyBandProfileIsDisplayed()
    {
        // test variables
        string entity = "band_name";
        string name = "Metallica";
        string title = "Search results for \"Metallica\"";

        // test steps
        var desambiguation = header.Search(entity, name);
        var profile = desambiguation.TransitionToProfile(title);
        string pTitle = profile.GetPageTitle();
        Assert.AreEqual(pTitle, "Metallica", "Validate the page title is the expected one");
    }

    [Test]
    public void VerifyBandStatus()
    {
        // test variables
        string entity = "band_name";
        string name = "Metallica";
        string title = "Search results for \"Metallica\"";

        // test steps
        var desambiguation = header.Search(entity, name);
        var profile = desambiguation.TransitionToProfile(title);
        string pStatus = profile.GetBandStatus();
        Assert.AreEqual(pStatus, "Active", "Validate the band status is the expected one");
    }
}