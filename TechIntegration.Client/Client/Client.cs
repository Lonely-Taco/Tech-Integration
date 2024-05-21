using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using TechIntegration.Infra.Interfaces;

namespace TechIntegration.Client.Client;

public class Client : IClient
{
    private readonly string _apiKey;
    private readonly string _apiToken;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    private const string BaseUrl = "https://api.trello.com/1/";

    public Client(IConfiguration configuration, HttpClient client)
    {
        _configuration = configuration;
        _httpClient = client;
        _apiKey = _configuration["TRELLO_API_KEY"]!;
        _apiToken = _configuration["TRELLO_API_TOKEN"]!;
    }

    public async Task<string> GetTrelloBoards()
    {
        string endpoint = "members/me/boards";
        string url = $"{BaseUrl}{endpoint}?key={_apiKey}&token={_apiToken}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }

        return string.Empty;
    }

    public string GetAuthorizationUrl()
    {
        return
            $"https://trello.com/1/authorize?expiration=30days&name=MyPersonalToken&scope=read,write&response_type=token&key={_apiKey}";
    }

    public async Task<string> GetTrelloLists()
    {
        string endpoint = $"boards/{_configuration["TRELLO_API_BOARDID"]}/lists";
        string url = $"{BaseUrl}{endpoint}?key={_apiKey}&token={_apiToken}";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }

        return string.Empty;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{BaseUrl}{url}key={_apiKey}&token={_apiToken}"),
            VersionPolicy = HttpVersionPolicy.RequestVersionOrLower
        };

        HttpResponseMessage res = await _httpClient.SendAsync(request);

        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(res.Content.ReadAsStringAsync().Result);
        }
        
        return JsonConvert.DeserializeObject<T>(res.Content.ReadAsStringAsync().Result)!;
    }

    public async Task<T> PostAsync<T>(string url, HttpMethod method, HttpContent? content = null)
    {
        HttpRequestMessage request = new HttpRequestMessage
        {
            Content = content,
            Method = method,
            RequestUri = new Uri($"{BaseUrl}{url}&key={_apiKey}&token={_apiToken}"),

            VersionPolicy = HttpVersionPolicy.RequestVersionOrLower
        };

        HttpResponseMessage res = await _httpClient.SendAsync(request);

        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(res.Content.ReadAsStringAsync().Result);
        }

        return JsonConvert.DeserializeObject<T>(res.Content.ReadAsStringAsync().Result)!;
    }

    public async Task DeleteAsync(string url)
    {
        HttpRequestMessage request = new HttpRequestMessage
        {
            Content = null,
            Method = HttpMethod.Delete,
            RequestUri = new Uri($"{BaseUrl}{url}?key={_apiKey}&token={_apiToken}"),
            VersionPolicy = HttpVersionPolicy.RequestVersionOrLower
        };

        HttpResponseMessage res = await _httpClient.SendAsync(request);

        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(res.Content.ReadAsStringAsync().Result);
        }
    }

    public async Task<string> PutAsync(string url, HttpContent content)
    {
        HttpRequestMessage request = new HttpRequestMessage
        {
            Content = content,
            Method = HttpMethod.Put,
            RequestUri = new Uri($"{BaseUrl}{url}?key={_apiKey}&token={_apiToken}"),
            VersionPolicy = HttpVersionPolicy.RequestVersionOrLower
        };

        HttpResponseMessage res = await _httpClient.SendAsync(request);

        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(res.Content.ReadAsStringAsync().Result);
        }

        return res.Content.ReadAsStringAsync().Result;
    }
}