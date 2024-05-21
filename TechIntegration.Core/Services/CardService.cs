using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TechIntegration.Core.Models;
using TechIntegration.Infra.Interfaces;
using TechIntegration.Infra.Requests;
using TechIntegration.Infra.Trello.List;
using Microsoft.Extensions.Configuration;

namespace TechIntegration.Core.Services;

public class CardService(IClient client, IConfiguration configuration) : ICardService
{
    private readonly Dictionary<string, string> listDictionary = new();

    public async Task GenerateCardAsync(IAsyncEnumerable<Tender> tenders)
    {
        List<BoardList> boardLists = await client.GetAsync<List<BoardList>>(
            $"boards/{configuration["TRELLO_API_BOARDID"]}/lists?"
        );
        
        foreach (var list in boardLists)
        {
            if (list.Name == "Status1")
            {
                listDictionary["Status1"] = list.Id;
            }

            if (list.Name == "Status2")
            {
                listDictionary["Status2"] = list.Id;
            }

            if (list.Name == "Status3")
            {
                listDictionary["Status3"] = list.Id;
            }
        }

        await foreach (var tender in tenders)
        {
            await CreatCard(tender, listDictionary[StatusDictionary.Dictionary[tender.Status]], boardLists);
        }
    }

    private async Task CreatCard(Tender tender, string listId, List<BoardList> boardList)
    {
        var existingCard = await CheckExistingCards(boardList, tender.TenderId.ToString(), tender.LotNumber!);

        if (existingCard != null)
        {
            var statusField =
                existingCard.CustomFieldItems.FirstOrDefault(customField =>
                    customField.IdCustomField == "664c33d7cb3d78254f013830");

            if (!StatusDictionary.Dictionary[tender.Status].Equals(statusField!.Value.Text))
            {
                await client.DeleteAsync($"cards/{existingCard.Id}");

                existingCard = await CreateNewCard(tender, listId);
            }

            await UpdateFields(tender, existingCard);

            return;
        }

        var card = await CreateNewCard(tender, listId);


        await UpdateFields(tender, card);
    }

    private async Task<Card> CreateNewCard(Tender tender, string listId)
    {
        HttpContent content = new StringContent(
            JsonConvert.SerializeObject(PostCard.CreateCardRequestFromTender(tender, listId)),
            Encoding.UTF8,
            "application/json"
        );

        Card card = await client.PostAsync<Card>(
            $"cards?idList={listId}",
            HttpMethod.Post,
            content
        );
        return card;
    }

    private async Task<Card?> CheckExistingCards(List<BoardList> boardList, string tenderId, string lotNumber)
    {
        if (lotNumber.Equals("-"))
        {
            return null;
        }

        foreach (var list in boardList)
        {
            var cards = await client.GetAsync<List<Card>>(
                $"lists/{list.Id}/cards?customFieldItems=true&");

            foreach (var card in cards)
            {
                var lotNumberField =
                    card.CustomFieldItems.FirstOrDefault(customField =>
                        customField.IdCustomField == "664b49118b19674273387139");
                var tenderIdField =
                    card.CustomFieldItems.FirstOrDefault(customField =>
                        customField.IdCustomField == "664a4116d3bb5c6b1fb12287");

                if (lotNumberField != null && tenderIdField != null &&
                    lotNumberField.Value.Text == lotNumber &&
                    tenderIdField.Value.Text == tenderId)
                {
                    return card;
                }
            }
        }

        return null;
    }

    private async Task UpdateFields(Tender tender, Card card)
    {
        List<Field> fields =
            await client.GetAsync<List<Field>>($"boards/{configuration["TRELLO_API_BOARDID"]}/customFields?");

        FieldRequest fieldRequest = FieldRequest.CreatFieldRequestFromFields(fields, tender);

        HttpContent fieldRequestContent = new StringContent(
            JsonConvert.SerializeObject(fieldRequest),
            Encoding.UTF8,
            "application/json"
        );

        await client.PutAsync(
            $"cards/{card.Id}/customFields",
            fieldRequestContent
        );
    }
}