using ClansAPI.Data.Entities;
using ClansAPI.Interfaces;
using ClansAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClansAPI.Controllers;

[ApiController]
[Route("api/clans")]
public class ClansController : ControllerBase
{
    private readonly IClanService _clanService;

    public ClansController(IClanService clanService)
    {
        _clanService = clanService;
    }

    [HttpPost]
    public async Task<ClanModel> CreateClanAsync([FromBody] ClanModel clanModel)
    {
        return await _clanService.CreateClanAsync(clanModel);
    }

    [HttpGet]
    public async Task<List<ClanModel>> GetAllClansAsync()
    {
        return await _clanService.GetAllClansAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ClanModel> GetClanByIdAsync([FromRoute] int id)
    {
        return await _clanService.GetClanByIdAsync(id);
    }

    [HttpPatch("{id:int}")]
    public async Task<ClanModel> ChangeClanDescriptionAsync([FromBody] ClanModel updatedDescription, int id)
    {
        return await _clanService.ChangeClanDescriptionAsync(updatedDescription, id);
    }
}