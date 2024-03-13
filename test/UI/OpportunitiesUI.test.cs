using Project.src.framework.automation;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace Project.test.UI;

[TestFixture]
public class OpportunitiesUITest : AutomationBase
{
    
    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifyQaOpportunityExists()
    {
        // test variables
        string[] requiredOpportunity = {"QA", "Quality Assurance", "Tester"};
        // test steps
        careers.ShowAvailablePositions();
        var index = careers.SearchOpportunity(requiredOpportunity);
        Assert.That(index, Is.Not.EqualTo(-1), "There was no 'Quality Assurance' position listed");
        // I'm not checking the form since there's no requirement related to what should I look for in it
    }
}