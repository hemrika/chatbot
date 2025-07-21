using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FAQChatbot;
using Xunit;

public class FakeHandler : HttpMessageHandler
{
    public HttpRequestMessage? LastRequest { get; private set; }
    private readonly string _response;

    public FakeHandler(string response)
    {
        _response = response;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        LastRequest = request;
        var message = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_response)
        };
        return Task.FromResult(message);
    }
}

public class OpenAIServiceTests
{
    [Fact]
    public async Task Ask_Returns_Message_Content()
    {
        var json = "{\"choices\":[{\"message\":{\"content\":\"hello\"}}]}";
        var handler = new FakeHandler(json);
        var service = new OpenAIService("test-key", handler);

        var result = await service.Ask("test");

        Assert.Equal("hello", result);
        Assert.NotNull(handler.LastRequest);
        Assert.Equal("https://api.openai.com/v1/chat/completions", handler.LastRequest!.RequestUri!.ToString());
    }
}
