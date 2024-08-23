using AgoraDotNet.Core.Entities;
using AgoraDotNet.Core.Interfaces;

namespace AgoraDotNet.Infrastructure.Runtime;

public class InMemoryUserManager : IRuntimeUserManager
{
    private readonly Dictionary<string, RuntimeUser> _connectedUsers = new Dictionary<string, RuntimeUser>();

    public RuntimeUser GetUserByUsername(string username)
    {
        _connectedUsers.TryGetValue(username, out var user);
        return user;
    }

    public void AddUser(RuntimeUser user)
    {
        if (!_connectedUsers.ContainsKey(user.Username))
        {
            _connectedUsers[user.Username] = user;
        }
    }

    public void RemoveUser(string username)
    {
        _connectedUsers.Remove(username);
    }
}