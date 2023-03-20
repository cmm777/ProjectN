using Project.src.framework.automation;
using NUnit.Framework;
using System.Net;
using AventStack.ExtentReports;

namespace Project.test.API;

[TestFixture]
public class BandAPITest : AutomationBase
{
    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public async Task VerifyExistingBand()
    {
        test.Log(Status.Info, "Test objective is to validate the response code when searching for an existing band");
        using var httpClient = new HttpClient();
        test.Log(Status.Info, "Sending the request");
        var response = await httpClient.GetAsync("https://www.metal-archives.com/bands/band/125");
        test.Log(Status.Info, "response code is "+response.StatusCode);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public async Task VerifyUnexistingBand()
    {
        test.Log(Status.Info, "Test objective is to validate the response code when searching for an unexisting band");
        using var httpClient = new HttpClient();
        test.Log(Status.Info, "Sending the request");
        var response = await httpClient.GetAsync("https://www.metal-archives.com/bands/band/2");
        test.Log(Status.Info, "response code is "+response.StatusCode);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public async Task VerifyBandStatus()
    {
        test.Log(Status.Info, "Test objective is to validate the band status is \"United States\"");
        using var httpClient = new HttpClient();
        test.Log(Status.Info, "Sending the request");
        string response = await httpClient.GetStringAsync("https://www.metal-archives.com/search/ajax-band-search/?field=name&query=Metallica&sEcho=1&iColumns=3&sColumns=&iDisplayStart=0&iDisplayLength=200&mDataProp_0=0&mDataProp_1=1&mDataProp_2=2");
        StringAssert.Contains("error\": \"", response, "Validate there were no errors");
        StringAssert.Contains("\"iTotalRecords\": 1", response, "Validate there is only one band with the name");
        StringAssert.Contains("United States", response, "Validate the band country");
    }
}