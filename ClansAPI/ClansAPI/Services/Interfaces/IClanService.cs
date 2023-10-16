using ClansAPI.Data.Entities;
using ClansAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClansAPI.Interfaces;

public interface IClanService
{
    Task<ClanModel> CreateClanAsync([FromBody] ClanModel clanModel);
    Task<List<ClanModel>> GetAllClansAsync();
    Task<ClanModel?> GetClanByIdAsync([FromRoute] int id);
    Task<ClanModel> ChangeClanDescriptionAsync([FromBody] ClanModel updatedDescription, int id);
}