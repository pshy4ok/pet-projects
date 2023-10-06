using Microsoft.AspNetCore.Mvc;

namespace ClansAPI.Controllers;

[ApiController]
[Route("api/clans")]
public class ClansController : ControllerBase
{
    [HttpPost(Name = "CreateClan")]
    public IActionResult CreateClan([FromBody] ClanModel clan)
    {
        ClansList.clanList.Add(clan);
        return CreatedAtRoute("GetClanById", new { id = clan.Id }, clan);
    }

    [HttpGet(Name = "GetAllClans")]
    public IActionResult GetAllClans()
    {
        return Ok(ClansList.clanList);
    }

    [HttpGet("{id:int}", Name = "GetClanById")]
    public IActionResult GetClanById(int id)
    {
        var clan = ClansList.clanList.FirstOrDefault(c => c.Id == id);

        if (clan == null)
        {
            return NotFound();
        }

        return Ok(clan);
    }

    [HttpPatch(Name = "ChangeClanDescription")]
    public IActionResult ChangeClanDescription([FromBody] ClanModel updatedDescription, int id)
    {
        var existingDescription = ClansList.clanList.FirstOrDefault(c => c.Id == id);

        if (existingDescription == null)
        {
            return NotFound();
        }

        existingDescription.Description = updatedDescription.Description;
        return Ok(existingDescription);
    }
}