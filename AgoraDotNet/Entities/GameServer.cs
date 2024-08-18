namespace AgoraDotNet.Entities;

public class GameServer
{
    public int GameServerId;

    public List<ConnectedUser> Clients { get; set; } = new List<ConnectedUser>();
    
    public void AddClient(ConnectedUser client)
    {
        Clients.Add(client);
    }

    public void RemoveClient(ConnectedUser client)
    {
        Clients.Remove(client);
    }
}