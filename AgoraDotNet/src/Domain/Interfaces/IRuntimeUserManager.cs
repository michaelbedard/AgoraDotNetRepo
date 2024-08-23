using AgoraDotNet.Core.Entities;

namespace AgoraDotNet.Core.Interfaces
{
    public interface IRuntimeUserManager
    {
        RuntimeUser GetUserByUsername(string username);
        void AddUser(RuntimeUser user);
        void RemoveUser(string username);
    }
}