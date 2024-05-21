using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using TechIntegration.Core.Models;
using TechIntegration.Infra.Interfaces;

namespace TechIntegration.Core.Parser;

public class Parser : ICsvParse
{
    public async IAsyncEnumerable<Tender> ParseTender()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory,
            @"TechIntegration.Core/CSV Tenders/assignment-opportunities-v1.csv");

        if (!File.Exists(filePath))
        {
            yield break;
        }
        
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        await foreach (var record in csv.GetRecordsAsync<Tender>())
        {
            yield return record;
        }
    }
}