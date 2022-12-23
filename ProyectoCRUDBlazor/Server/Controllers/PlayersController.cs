using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCRUDBlazor.Server.Core.Entities;
using ProyectoCRUDBlazor.Server.Core.Service.Interface;

namespace ProyectoCRUDBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _service;

    public PlayersController(IPlayerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Player>>> Get()
    {
        var players = await _service.GetAllPlayerAsync();
        return Ok(players);
    }

    [HttpGet("{id}", Name ="getPlayer")]
    public async Task<ActionResult<Player>> Get(int id)
    {
        var player = await _service.GetPlayerAsync(id);
        return Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Player player)
    {
        await _service.CreatePlayerAsync(player);
        return new CreatedAtRouteResult("getPlayer", new { id = player.Id }, player);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Player player)
    {
        await _service.UpdatePlayerAsync(id, player);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteByIdAsync(id);
        return NoContent();
    }
}
