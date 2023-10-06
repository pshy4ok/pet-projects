namespace ClansAPI;

public class ClansList
{
    private static ClansList _instance;
    public static List<ClanModel> clanList = new List<ClanModel>();

    public static ClansList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ClansList();
            }

            return _instance;
        }
    }
}