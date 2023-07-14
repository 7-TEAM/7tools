using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SvTools.Services;

public class HttpService : IHttpService
{
    private const string Url = "https://xyz.com/api/";
    private readonly HttpClient _client;

    public HttpService(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> SendRequest(string endpoint)
    {
        throw new System.NotImplementedException();
    }

    public async Task<string> SendGet(string endpoint)
    {
        using var response = await _client.GetAsync($"{Url}{endpoint}");
        if (!response.IsSuccessStatusCode) throw new IOException("Status code is not success.");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SendPost(string endpoint)
    {
        throw new System.NotImplementedException();
    }
}