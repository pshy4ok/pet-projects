using ClansAPI.Models;

namespace ClansAPI.Data.Entities;

public class Clan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}