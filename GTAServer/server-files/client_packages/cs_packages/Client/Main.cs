using System.Data.SqlTypes;
using RAGE;
using RAGE.Game;
using RAGE.Ui;

namespace Client
{
    public class Main : Events.Script
    {
        HtmlWindow openedWindow;
        private readonly string htmlWindowPath = "C://RAGEMP/server-files/client_packages/cef/auth/index.html";

        public Main()
        {
            Events.OnPlayerReady += OnPlayerReady;
            Events.OnPlayerSpawn += OnPlayerSpawn;
            Events.OnPlayerCreateWaypoint += OnPlayerCreateWaypoint;
            Events.Add("closeWindow", OnCloseWindow);
        }

        public void OnPlayerReady()
        {
            Chat.Output("Welcome!");
        }
        
        public void OnCloseWindow(object[] args)
        {
            openedWindow.Destroy();
            Cursor.ShowCursor(false, false);
        }

        public void OnPlayerSpawn(Events.CancelEventArgs cancel)
        {
            openedWindow = new HtmlWindow(htmlWindowPath);
            openedWindow.Active = true;
            Cursor.ShowCursor(true, true);
        }

        public void OnPlayerCreateWaypoint(Vector3 position)
        {
            Events.CallRemote("CLIENT:SERVER::CLIENT_CREATE_WAYPOINT", position.X, position.Y, position.Z);
        }
    }
}