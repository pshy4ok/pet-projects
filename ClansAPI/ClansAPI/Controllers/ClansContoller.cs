using ClansAPI.Interfaces;
using ClansAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClansAPI.Controllers;

[ApiController]
[Route("api/clans")]
public class ClansController : ControllerBase
{
    private readonly IClansStorage _clansStorage;

    public ClansController(IClansStorage clansStorage)
    {
        _clansStorage = clansStorage;
    }
    
    [HttpPost]
    public ClanModel CreateClan([FromBody] ClanModel clanModel)
    {
        return _clansStorage.CreateClan(clanModel);
    }
    
    [HttpGet]
    public List<ClanModel> GetAllClans()
    {
        return _clansStorage.GetAllClans();
    }
    
    [HttpGet("{id:int}")]
    public ClanModel GetClanById([FromRoute] int id)
    {
        return _clansStorage.GetClanById(id);
    }

    [HttpPatch("{id:int}")]
    public ClanModel ChangeClanDescription([FromBody] ClanModel updatedDescription, int id)
    {
        return _clansStorage.ChangeClanDescription(updatedDescription, id);
    }
}