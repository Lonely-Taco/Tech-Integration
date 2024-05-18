namespace TechIntegration.Client.Client;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class Client : IClient
{
    private readonly string _apiKey;
    private readonly string _apiToken;
    private readonly IConfiguration _configuration;

    public Client(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiKey = _configuration["TRELLO_API_KEY"]!;
        _apiToken = _configuration["TRELLO_API_TOKEN"]!;
    }

    public async Task<string> GetTrelloBoards()
    {
        using HttpClient client = new HttpClient();

        string baseUrl = "https://api.trello.com/1";

        string endpoint = "/members/me/boards";
        string url = $"{baseUrl}{endpoint}?key={_apiKey}&token={_apiToken}";


        HttpResponseMessage response = await client.GetAsync(url);

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
            $"https://trello.com/1/authorize?expiration=1day&name=MyPersonalToken&scope=read&response_type=token&key={_apiKey}";
    }

    public async Task<string> GetTrelloLists()
    { 
        using HttpClient client = new HttpClient();

        string baseUrl = "https://api.trello.com/1";
        
        string endpoint = $"/boards/{_configuration["TRELLO_API_BOARDID"]}/lists";
        string url = $"{baseUrl}{endpoint}?key={_apiKey}&token={_apiToken}";

        HttpResponseMessage response = client.GetAsync(url).Result;

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
        else
        {
            Console.WriteLine($"Failed to retrieve lists: {response.StatusCode}, {response.ReasonPhrase}");
        }

        return string.Empty;
    }
}

public interface IClient
{
    public Task<string> GetTrelloBoards();
    public string GetAuthorizationUrl();
    public Task<string>  GetTrelloLists();
}