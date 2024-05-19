using System.Threading.Tasks;

namespace TechIntegration.Client.Client;

public interface IClient
{
    public Task<string> GetTrelloBoards();
    public string GetAuthorizationUrl();
    public Task<string> GetTrelloLists();
    public Task<T> GetAsync<T>(string url);
    public Task<T> PostAsync<T>(string url, HttpMethod method, HttpContent? content = null);
}