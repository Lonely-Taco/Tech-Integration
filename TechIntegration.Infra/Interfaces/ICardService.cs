using TechIntegration.Core.Models;

namespace TechIntegration.Infra.Interfaces;

public interface ICardService
{
    public Task GenerateCardAsync(IAsyncEnumerable<Tender> tenders);
}