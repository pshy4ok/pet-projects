using ClansAPI.Interfaces;
using ClansAPI.Models;

namespace ClansAPI;

public class ClansStorage : IClansStorage
{
    private readonly List<ClanModel> _clansList = new List<ClanModel>();

    public ClanModel CreateClan(ClanModel clanModel)
    {
        var clan = new ClanModel()
        {
            Id = clanModel.Id,
            Name = clanModel.Name,
            Description = clanModel.Description
        };
        _clansList.Add(clanModel);
        return clanModel;
    }

    public List<ClanModel> GetAllClans()
    {
        return _clansList;
    }

    public ClanModel GetClanById(int id)
    {
        var clan = _clansList.FirstOrDefault(c => c.Id == id);

        if (clan == null)
        {
            throw new Exception("Not Found!");
        }

        return clan;
    }

    public ClanModel ChangeClanDescription(ClanModel updatedDescription, int id)
    {
        var existingDescription = _clansList.FirstOrDefault(c => c.Id == id);

        if (existingDescription == null)
        {
            throw new Exception("Not Found!");
        }

        existingDescription.Description = updatedDescription.Description;
        return existingDescription;
    }
}