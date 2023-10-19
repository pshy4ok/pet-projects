using ClansAPI.Data.Entities;
using ClansAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClansAPI.Interfaces;

public interface IClanService
{
    Task<ClanModel> CreateClanAsync(ClanModel clanModel);
    Task<List<ClanModel>> GetAllClansAsync();
    Task<ClanModel?> GetClanByIdAsync(int id);
    Task<Clan> ChangeClanDescriptionAsync(string description, int id);
}