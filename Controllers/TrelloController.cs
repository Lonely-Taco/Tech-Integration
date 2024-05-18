using Microsoft.AspNetCore.Mvc;
using TechIntegration.Client.Client;
using TechIntegration.Core.Parser;

namespace TechIntegration.Controllers;

[ApiController]
[Route("[controller]")]
public class TrelloController(IClient client, ICsvParse parser) : ControllerBase
{
    [HttpGet("boards")]
    public async Task<IActionResult> GetBoards()
    {
        
        return Ok(await client.GetTrelloBoards());
    }
    
    [HttpGet("auth")]
    public IActionResult GetAuthUrl()
    {
        return Ok(client.GetAuthorizationUrl());
    }
    
    [HttpGet("cards")]
    public async Task<IActionResult> GetCards()
    {
        await parser.ParseTender();
        return Ok();
    }
    
    [HttpGet("lists")]
    public async Task<IActionResult> GetLists()
    {
        return Ok(await client.GetTrelloLists());
    }
}