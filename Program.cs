using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;

public class HttpClientFactoryBenchmark
{
    private HttpClient _httpClient;
    private IHttpClientFactory _httpClientFactory;

    [GlobalSetup]
    public void Setup()
    {
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .BuildServiceProvider();

        _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        _httpClient = new HttpClient();
    }

    [Benchmark]
    public async Task DefaultHttpClient()
    {
        using var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
        var content = await response.Content.ReadAsStringAsync();
    }

    [Benchmark]
    public async Task HttpClientWithFactory()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
        var content = await response.Content.ReadAsStringAsync();
    }

    [Benchmark]
    public async Task HttpClientWithFactoryAndHeadersRead()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts", HttpCompletionOption.ResponseHeadersRead);
        var stream = await response.Content.ReadAsStreamAsync(); // reading as a stream
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _httpClient.Dispose();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<HttpClientFactoryBenchmark>();
    }
}
