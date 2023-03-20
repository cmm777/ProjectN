using NUnit.Framework;

namespace Project.src.framework.automation;

public class AutomationBaseAPI : ReportGeneration
{
    [SetUp]
    public void Setup()
    {
        base.Setup("API");
    }

    [OneTimeSetUp]
    public new void ExtentStart()
    {
        base.ExtentStart();
    }

    [TearDown]
    public new void TearDown()
    {
        base.TearDown();
    }
    
    [OneTimeTearDown]
    public new void ExtentClose()
    {
        base.ExtentClose();
    }
}
