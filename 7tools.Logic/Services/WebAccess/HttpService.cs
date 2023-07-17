﻿namespace SvTools.Services.WebAccess;

public class HttpService : IHttpService
{
    private const string Url = "http://localhost:3000/";
    private readonly HttpClient _client;

    public HttpService(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> SendGet(string endpoint)
    {
        using var response = await _client.GetAsync($"{Url}{endpoint}");
        if (!response.IsSuccessStatusCode) throw new IOException("Status code is not success.");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SendPost(string endpoint)
    {
        throw new NotImplementedException();
    }
}