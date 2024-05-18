using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using TechIntegration.Core.Models;

namespace TechIntegration.Core.Parser;

public class Parser : ICsvParse
{
    public Task ParseTender()
    {
        var csvContent =
            @"Id,TenderId,LotNumber,Deadline,Name,TenderName,ExpirationDate,HasDocuments,Location,PublicationDate,Status,Currency,Value
7A3DAA68-458F-4F92-A7D9-08DBBF541284,6A07D6E2-6C07-4554-89CB-D8174EEE9D68,-,,Marktconsultatie - Gemeente Zwolle - Leveren van verlichting voor vier iconen,Marktconsultatie - Gemeente Zwolle - Leveren van verlichting voor vier iconen,,TRUE,Nederland,2023-09-09 22:01:45.4424250 +00:00,3,EUR,651651
EAA4A48B-11EC-481D-A7DA-08DBBF541284,A5990108-F984-474A-9187-89EE4E658648,-,2024-02-12 11:00:00.0000000 +00:00,Inhuur flexibele arbeidskrachten,Inhuur flexibele arbeidskrachten,,TRUE,Amsterdam en omgeving,2023-09-09 09:15:41.9622670 +00:00,3,EUR,3648911
32513BC7-52DD-4BA9-A7DB-08DBBF541284,4A5B8C0F-26E0-4D11-B61E-F4525D0B8031,1,2023-10-30 10:00:00.0000000 +00:00,Perceel 1: Gemeente Beverwijk,Advisering en begeleiding isolatiemaatregelen eigenaar-bewoners,2027-12-31 00:00:00.0000000 +00:00,TRUE,IJmond en omgeving,2023-09-09 15:01:52.8301350 +00:00,2,EUR,51651";

        using var reader = new StringReader(csvContent);
        using var csv = new CsvReader(
            reader,
            new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
            }
        );
        var records = csv.GetRecords<Tender>();
        foreach (var record in records)
        {
            Console.WriteLine(
                $"Id: {record.Id}, TenderId: {record.TenderId}, Name: {record.Name}, Lot number: {record.LotNumber} Status: {record.Status} Value: {record.Value}"
            );
        }

        return Task.CompletedTask;
    }
}

public interface ICsvParse
{
    public Task ParseTender();
}