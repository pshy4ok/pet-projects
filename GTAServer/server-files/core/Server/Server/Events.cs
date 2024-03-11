using System.Data;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class Events : Script
{
    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        NAPI.Util.ConsoleOutput("Hello World!");
    }

    [ServerEvent(Event.PlayerSpawn)]
    public void OnPlayerSpawn(Player player)
    {
        player.Position = new Vector3(-2203.3652, 4609.78, 1.783841);
        player.Rotation = new Vector3(0, 0, 36.41761);
        player.Dimension = player.Id;
    }
}
