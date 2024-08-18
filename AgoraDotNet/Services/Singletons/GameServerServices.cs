using AgoraDotNet.Entities;

namespace AgoraDotNet.Services.Singletons
{
    public class GameServerService
    {
        private readonly List<GameServer> _gameServers = new List<GameServer>();

        public GameServer CreateGameServer()
        {
            var gameServer = new GameServer();
            _gameServers.Add(gameServer);
            return gameServer;
        }

        public void DeleteGameServer(int gameId)
        {
            var gameServer = _gameServers.FirstOrDefault(g => g.GameServerId == gameId);
            if (gameServer != null)
            {
                _gameServers.Remove(gameServer);
            }
        }

        public GameServer? FindGameServer(int gameServerId)
        {
            return _gameServers.FirstOrDefault(g => g.GameServerId == gameServerId);
        }
    }
}