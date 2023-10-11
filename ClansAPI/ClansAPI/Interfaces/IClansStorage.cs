using ClansAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClansAPI.Interfaces;

public interface IClansStorage
{
    ClanModel CreateClan([FromBody] ClanModel clanModel);
    List<ClanModel> GetAllClans();
    ClanModel GetClanById([FromRoute] int id);
    ClanModel ChangeClanDescription([FromBody] ClanModel updatedDescription, int id);
}