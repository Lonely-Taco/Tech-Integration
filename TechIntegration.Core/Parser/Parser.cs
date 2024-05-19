using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using TechIntegration.Core.Models;

namespace TechIntegration.Core.Parser;

public class Parser : ICsvParse
{
    public IAsyncEnumerable<Tender>? ParseTender()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory,
            @"TechIntegration.Core/CSV Tenders/assignment-opportunities-v2.csv");

        Console.WriteLine(filePath);

        if (!File.Exists(filePath)) return null;
        
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecordsAsync<Tender>();

    }
}

public interface ICsvParse
{
    public IAsyncEnumerable<Tender>? ParseTender();
}