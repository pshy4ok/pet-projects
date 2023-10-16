using ClansAPI.Data;
using ClansAPI.Data.Entities;
using ClansAPI.Interfaces;
using ClansAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClansAPI;

public class ClanService : IClanService
{
    private readonly ApplicationContext _applicationContext;

    public ClanService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<ClanModel> CreateClanAsync(ClanModel clanModel)
    {
        var clan = new Clan
        {
            Name = clanModel.Name,
            Description = clanModel.Description
        };
        
        await _applicationContext.Clans.AddAsync(clan);
        await _applicationContext.SaveChangesAsync();

        return clanModel;
    }

    public async Task<List<ClanModel>> GetAllClansAsync()
    {
        List<ClanModel> clanModels = _applicationContext.Clans.Select(clan => new ClanModel
        {
            Name = clan.Name,
            Description = clan.Description
        }).ToList();
        
        return clanModels;
    }

    public async Task<ClanModel?> GetClanByIdAsync(int id)
    {
        var clan = await _applicationContext.Clans.FirstOrDefaultAsync(c => c.Id == id);

        return clan != null
            ? new ClanModel
            {
                Name = clan.Name,
                Description = clan.Description
            }
            : null;
    }

    public async Task<ClanModel> ChangeClanDescriptionAsync(ClanModel updatedDescription, int id)
    {
        var existingDescription = await _applicationContext.Clans.FirstOrDefaultAsync(c => c.Id == id);

        existingDescription.Description = updatedDescription.Description;
        
        await _applicationContext.SaveChangesAsync();

        return updatedDescription;
    }
}