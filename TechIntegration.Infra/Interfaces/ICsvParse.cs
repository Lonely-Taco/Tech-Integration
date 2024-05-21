using TechIntegration.Core.Models;

namespace TechIntegration.Infra.Interfaces;

public interface ICsvParse
{
    public IAsyncEnumerable<Tender>? ParseTender();
}