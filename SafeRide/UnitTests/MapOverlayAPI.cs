using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;

using Xunit;

namespace SRUnitTests;

public class CustomWebAppFactory : WebApplicationFactory<Program>
{
    private readonly string _environment;

    public CustomWebAppFactory(string environment = "Development")
    {
        _environment = environment;
    }
}

public class MapOverlayAPI
{
    [Fact]
    public async Task GET_OK()
    {
        await using var application = new CustomWebAppFactory();

        using var client = application.CreateClient();
        using var response = await client.GetAsync("/api/testing/get_ok");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task POST_LoginToken_OK()
    {
        // arrange
        await using var application = new CustomWebAppFactory();
        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Post, "api/login");

        request.Content = new StringContent(JsonSerializer.Serialize(new
        {
            UserName = "apple",
            Email = "apple@gmail.com",
            Role = "admin",
            Valid = true
        }), Encoding.UTF8, "application/json");

        // act

        using var response = await client.SendAsync(request);
        
        // assert
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseToken = response.Content.ReadAsStringAsync().Result.Split(":")[1].Replace("\"", "").Replace("}", "");
        var expectedToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc";
        
        Assert.Equal(expectedToken, responseToken);
    }

    [Fact]
    public async Task POST_LongToken_FAIL()
    {
        // arrange
        await using var application = new CustomWebAppFactory();
        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Post, "api/login");

        request.Content = new StringContent(JsonSerializer.Serialize(new
        {
            UserName = "orange",
            Email = "apple@gmail.com",
            Role = "admin",
            Valid = true
        }), Encoding.UTF8, "application/json");

        // act

        using var response = await client.SendAsync(request);

        // assert

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GET_All_Overlays_OK()
    {
        // arrange 
        await using var application = new CustomWebAppFactory();
        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, "api/overlay/all");
        request.Headers.Authorization = AuthenticationHeaderValue.Parse("eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc");
        
        // act

        using var response = await client.SendAsync(request);

        // assert

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GET_All_Overlays_FAIL()
    {
        // arrange 
        await using var application = new CustomWebAppFactory();
        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, "api/overlay/all");
        request.Headers.Authorization = AuthenticationHeaderValue.Parse("yJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc");

        // act

        using var response = await client.SendAsync(request);

        // assert

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GET_Overlay_Dim_OK()
    {
        // arrange 
        await using var application = new CustomWebAppFactory();
        using var client = application.CreateClient();

        var queryString = new Dictionary<string, string>()
        {
            { "overlayName", "csulb" }
        };

        var requestUri = QueryHelpers.AddQueryString("api/overlay/all", queryString);

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        request.Headers.Authorization = AuthenticationHeaderValue.Parse("eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc");

        // act

        using var response = await client.SendAsync(request);

        // assert

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Fact]
    public async Task GET_Overlay_Dim_FAIL()
    {
        // arrange 
        await using var application = new CustomWebAppFactory();
        using var client = application.CreateClient();

        var queryString = new Dictionary<string, string>()
        {
            { "overlayName", "csulb" }
        };

        var requestUri = QueryHelpers.AddQueryString("api/overlay/all", queryString);

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        request.Headers.Authorization = AuthenticationHeaderValue.Parse("yJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc");

        // act

        using var response = await client.SendAsync(request);

        // assert

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);

    }
}