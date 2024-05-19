using System.Globalization;
using System.Text;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechIntegration.Client.Client;
using TechIntegration.Core.Models;
using TechIntegration.Core.Parser;
using TechIntegration.Infra.Requests;

namespace TechIntegration.Controllers;

[ApiController]
[Route("[controller]")]
public class TrelloController(IClient client, ICsvParse parser) : ControllerBase
{
    [HttpGet("boards")]
    public async Task<IActionResult> FindAllBoards()
    {
        return Ok(await client.GetTrelloBoards());
    }

    [HttpGet("auth")]
    public IActionResult GetAuthUrl()
    {
        return Ok(client.GetAuthorizationUrl());
    }

    [HttpGet("cards")]
    public async Task<IActionResult> FindAllCards()
    {

        var tenders = parser.ParseTender();

        if (tenders == null) return NotFound();
        
        await foreach (var tender in parser.ParseTender()!)
        {
            Console.WriteLine($"Id: {tender.Id}, Name: {tender.Name}, Value: {tender.Value}");
        }
        return Ok();

    }

    [HttpGet("card/{id}")]
    public async Task<IActionResult> FindOneCard(string id)
    {
        return Ok(await client.GetAsync<Card>($"cards/{id}"));
    }

    [HttpGet("lists")]
    public async Task<IActionResult> FindAllLists()
    {
        return Ok(await client.GetTrelloLists());
    }

    [HttpGet("list/{id}")]
    public async Task<IActionResult> FindOneList(string id)
    {
        return Ok(await client.GetAsync<Board>($"lists/{id}"));
    }

    [HttpGet("list/cards/{id}")]
    public async Task<IActionResult> FindAllCardsForList(string id)
    {
        return Ok(await client.GetAsync<List<Card>>($"lists/{id}/cards"));
    }

    [HttpPost("card/{listId}")]
    public async Task<IActionResult> CreateCard(string listId, [FromBody] PostCard request)
    {
        HttpContent content = new StringContent(
            JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json"
        );

        return Ok(await client.PostAsync<Card>($"cards?idList={listId}", HttpMethod.Post, content));
    }
}