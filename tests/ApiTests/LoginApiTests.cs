using System.Net;
using Allure.Net.Commons;
using NUnit.Framework;
using RestSharp;

namespace ApiTests;

[Allure.NUnit.AllureNUnit]
public class LoginApiTests
{
    private RestClient _client = null!;

    [SetUp]
    public void SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "http://localhost:5078";
        _client = new RestClient(new RestClientOptions(baseUrl));
    }

    [Test]
    [Allure.NUnit.Attributes.AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    public async Task HealthEndpoint_ReturnsOk()
    {
        var request = new RestRequest("/api/health", Method.Get);
        var response = await _client.ExecuteAsync<ApiResponse>(request);

        AllureApi.AddTestParameter("Endpoint", "/api/health");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Success, Is.True);
        Assert.That(response.Data.Message, Does.Contain("healthy"));
    }

    [Test]
    [Allure.NUnit.Attributes.AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
    public async Task LoginEndpoint_WithValidCredentials_ReturnsWelcomeMessage()
    {
        var request = new RestRequest("/api/login", Method.Post)
            .AddJsonBody(new LoginRequest("qa.user@example.com", "Password123!"));

        var response = await _client.ExecuteAsync<LoginResponse>(request);

        AllureApi.AddTestParameter("Endpoint", "/api/login");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Success, Is.True);
        Assert.That(response.Data.User, Is.Not.Null);
        Assert.That(response.Data.User!.DisplayName, Is.EqualTo("QA Demo User"));
    }

    [Test]
    [Allure.NUnit.Attributes.AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
    public async Task LoginEndpoint_WithInvalidCredentials_ReturnsBadRequest()
    {
        var request = new RestRequest("/api/login", Method.Post)
            .AddJsonBody(new LoginRequest("qa.user@example.com", "WrongPassword!"));

        var response = await _client.ExecuteAsync<ApiResponse>(request);

        AllureApi.AddTestParameter("Endpoint", "/api/login");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Success, Is.False);
    }
}

public record LoginRequest(string Email, string Password);
public record ApiResponse(bool Success, string Message);
public record UserProfile(string Email, string DisplayName);
public record LoginResponse(bool Success, string Message, UserProfile? User);
