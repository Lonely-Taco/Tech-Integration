using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechIntegration.Core.Models;
using TechIntegration.Infra.Interfaces;
using TechIntegration.Infra.Requests;
using TechIntegration.Infra.Trello.List;

namespace TechIntegration.Controllers;

[ApiController]
[Route("[controller]")]
public class TrelloController(
    IClient client,
    ICsvParse parser,
    ICardService cardService,
    IConfiguration configuration
) : ControllerBase
{
    [HttpGet("boards")]
    public async Task<IActionResult> FindAllBoards()
    {
        return Ok(await client.GetAsync<List<Board>>("members/me/boards?"));
    }

    [HttpGet("fields")]
    public async Task<IActionResult> FindAllFields()
    {
        return Ok(await client.GetAsync<List<Field>>($"boards/{configuration["TRELLO_API_BOARDID"]}/customFields?"));
    }

    [HttpGet("auth")]
    public IActionResult GetAuthUrl()
    {
        return Ok(client.GetAuthorizationUrl());
    }

    [HttpGet("cards/create")]
    public async Task<IActionResult> CreateAllCards()
    {
        var tenders = parser.ParseTender();

        if (tenders == null) return NotFound();

        await cardService.GenerateCardAsync(tenders);

        return Ok();
    }

    [HttpGet("card/{id}")]
    public async Task<IActionResult> FindOneCard(string id)
    {
        return Ok(await client.GetAsync<Card>($"cards/{id}?customFieldItems=true&"));
    }

    [HttpGet("card/fields/{id}")]
    public async Task<IActionResult> FindFields(string id, string fieldId)
    {
        return Ok(await client.GetAsync<Card>($"cards/{id}/customField/{fieldId}/item?"));
    }

    [HttpGet("lists")]
    public async Task<IActionResult> FindAllLists()
    {
        return Ok(await client.GetAsync<List<BoardList>>($"boards/{configuration["TRELLO_API_BOARDID"]}/lists?"));
    }

    [HttpGet("list/{id}")]
    public async Task<IActionResult> FindOneList(string id)
    {
        return Ok(await client.GetAsync<Board>($"lists/{id}"));
    }

    [HttpGet("list/cards/{id}")]
    public async Task<IActionResult> FindAllCardsForList(string id)
    {
        return Ok(await client.GetAsync<List<Card>>($"lists/{id}/cards?customFieldItems=true&"));
    }

    [HttpPost("card/{listId}")]
    public async Task<IActionResult> CreateCard(string listId, [FromBody] PostCard request)
    {
        HttpContent content = new StringContent(
            JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json"
        );

        return Ok(
            await client.PostAsync<Card>(
                $"cards?idList={listId}",
                HttpMethod.Post,
                content
            )
        );
    }

    [HttpDelete("cards/delete")]
    public async Task<IActionResult> DeleteAllClosed()
    {
        List<Card> cardsToDelete =
            await client.GetAsync<List<Card>>($"boards/{configuration["TRELLO_API_BOARDID"]}/cards/closed?");

        foreach (Card card in cardsToDelete)
        {
            await client.DeleteAsync($"cards/{card.Id}");
        }

        return Ok();
    }
}