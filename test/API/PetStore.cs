using Project.src.framework.automation;
using NUnit.Framework;
using RestSharp;

namespace Project.test.API;

[TestFixture]
public class PetStore : AutomationBase
{
    
    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC1VerifyUnexistingRecord()
    {
        RestRequest request = new RestRequest("pet/202020", Method.Delete);
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.AnyOf(200, 404));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC2CreatePet()
    {
        string requestBody = @"
        {
        ""id"": 202020,
        ""category"":
        {
            ""id"": 1,
            ""name"": ""dogs""
        },
        ""name"": ""Rufus"",
        ""photoUrls"": [""string""],
        ""tags"":
        [
            {
                ""id"": 17,
                ""name"": ""small""
            },
            {
                ""id"": 25,
                ""name"": ""short hair""
            }
        ],
        ""status"": ""available""
        }";

        RestRequest request = new RestRequest("pet", Method.Post);
        request.AddBody(requestBody);
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Content, Does.Contain("\"category\":{\"id\":1,\"name\":\"dogs\"}"));
        Assert.That(response.Content, Does.Contain("\"name\":\"Rufus\""));
        Assert.That(response.Content, Does.Contain("\"tags\":[{\"id\":17,\"name\":\"small\"},{\"id\":25,\"name\":\"short hair\"}]"));
        Assert.That(response.Content, Does.Contain("\"status\":\"available\""));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC3FindPetById()
    {
        RestRequest request = new RestRequest("pet/202020", Method.Get);
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Content, Does.Contain("\"category\":{\"id\":1,\"name\":\"dogs\"}"));
        Assert.That(response.Content, Does.Contain("\"name\":\"Rufus\""));
        Assert.That(response.Content, Does.Contain("\"tags\":[{\"id\":17,\"name\":\"small\"},{\"id\":25,\"name\":\"short hair\"}]"));
        Assert.That(response.Content, Does.Contain("\"status\":\"available\""));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC4UpdatePetJson()
    {
        string requestBody = @"
        {
        ""id"": 202020,
        ""category"":
        {
            ""id"": 1,
            ""name"": ""dogs""
        },
        ""name"": ""Rufus"",
        ""photoUrls"": [""string""],
        ""tags"":
        [
            {
                ""id"": 18,
                ""name"": ""medium""
            },
            {
                ""id"": 25,
                ""name"": ""short hair""
            }
        ],
        ""status"": ""available""
        }";

        RestRequest request = new RestRequest("pet", Method.Put);
        request.AddBody(requestBody);
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.AnyOf(200));
        Assert.That(response.Content, Does.Contain("\"category\":{\"id\":1,\"name\":\"dogs\"}"));
        Assert.That(response.Content, Does.Contain("\"name\":\"Rufus\""));
        Assert.That(response.Content, Does.Contain("\"tags\":[{\"id\":18,\"name\":\"medium\"},{\"id\":25,\"name\":\"short hair\"}]"));
        Assert.That(response.Content, Does.Contain("\"status\":\"available\""));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC5UpdatePetForm()
    {
        RestRequest request = new RestRequest("pet/202020", Method.Post);
        request.AddParameter("status", "sold");
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Content, Does.Contain("\"message\":\"202020\""));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC6FindPetByStatus()
    {
        RestRequest request = new RestRequest("pet/findByStatus", Method.Get);
        request.AddParameter("status", "sold");
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Content, Does.Contain("\"name\":\"Rufus\""));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC7DeletePet()
    {
        RestRequest request = new RestRequest("pet/202020", Method.Delete);
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Content, Does.Contain("\"message\":\"202020\""));
    }

    [Test]
    [Category("API")]
    [Author("Cristian Maillard")]
    public void TC8VerifyPetDeleted()
    {
        RestRequest request = new RestRequest("pet/202020", Method.Get);
        RestResponse response = apiClient.Execute(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(404));
        Assert.That(response.Content, Does.Contain("\"message\":\"Pet not found\""));
    }
}