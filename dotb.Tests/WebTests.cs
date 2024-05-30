using System.Net;

namespace dotb.Tests;

public class WebTests {

    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode() {
        // Arrange
        IDistributedApplicationTestingBuilder appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.dotb_AppHost>();
        await using DistributedApplication app = await appHost.BuildAsync();
        await app.StartAsync();

        // Act
        HttpClient httpClient = app.CreateHttpClient("webfrontend");
        HttpResponseMessage response = await httpClient.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}