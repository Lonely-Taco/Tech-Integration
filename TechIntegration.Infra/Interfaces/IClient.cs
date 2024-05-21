using System.Threading.Tasks;

namespace TechIntegration.Infra.Interfaces;

public interface IClient
{
    public Task<string> GetTrelloBoards();

    public string GetAuthorizationUrl();

    public Task<string> GetTrelloLists();

    public Task<T> GetAsync<T>(string url);

    public Task<T> PostAsync<T>(
        string url,
        HttpMethod method,
        HttpContent? content = null
    );

    public Task DeleteAsync(string url);
    public Task<string> PutAsync(string url, HttpContent content);
}