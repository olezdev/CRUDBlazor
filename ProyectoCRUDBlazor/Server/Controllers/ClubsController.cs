using Microsoft.AspNetCore.Mvc;
using ProyectoCRUDBlazor.Server.Core.Entities;
using ProyectoCRUDBlazor.Server.Core.Service.Interface;

namespace ProyectoCRUDBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClubsController : ControllerBase
{
    private readonly IClubService _service;

    public ClubsController(IClubService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Club>>> Get()
    {
        return await _service.GetAllClubAsync();
    }


    [HttpGet("{id}", Name = "getClub")]
    public async Task<ActionResult<Club>> Get(int id)
    {
        return await _service.GetClubAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Club club)
    {
        await _service.CreateAsync(club);
        return new CreatedAtRouteResult("getClub", new { id = club.Id }, club);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Club club)
    {
        await _service.UpdateClubAsync(id, club);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {   
        await _service.DeleteByIdAsync(id);
        return Ok();
    }
}