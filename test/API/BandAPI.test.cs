using Project.src.framework.automation;
using NUnit.Framework;
using System.Net;
using System.Text.Json.Nodes;

namespace Project.test.UI;

[TestFixture]
public class BandAPITest : AutomationBaseAPI
{
    [Test]
    public async Task VerifyExistingBand()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://www.metal-archives.com/bands/Metallica/125");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Test]
    public async Task VerifyUnexistingBand()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://www.metal-archives.com/bands/Morcillalica");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Test]
    public async Task VerifyBandStatus()
    {
        using var httpClient = new HttpClient();
        string response = await httpClient.GetStringAsync("https://www.metal-archives.com/search/ajax-band-search/?field=name&query=Metallica&sEcho=1&iColumns=3&sColumns=&iDisplayStart=0&iDisplayLength=200&mDataProp_0=0&mDataProp_1=1&mDataProp_2=2");
        StringAssert.Contains("error\": \"", response, "Validate there were no errors");
        StringAssert.Contains("\"iTotalRecords\": 1", response, "Validate there is only one band with the name");
        StringAssert.Contains("United States", response, "Validate the band country");
    }
}