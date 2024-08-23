using AgoraDotNet.Core.Entities;

namespace AgoraDotNet.Core.Interfaces;

public interface IUserRepository
{
    Task<User> GetByUsername(string username);
}