using AgoraDotNet.Core.Entities;
using AgoraDotNet.Core.Interfaces;

namespace AgoraDotNet.Application.Services;

public class LoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IRuntimeUserManager _runtimeUserManager;

    public LoginService(IUserRepository userRepository, IRuntimeUserManager runtimeUserManager)
    {
        _userRepository = userRepository;
        _runtimeUserManager = runtimeUserManager;
    }

    public async Task<bool> Login(string username, string password)
    {
        var user = await _userRepository.GetByUsername(username);
        if (user == null || !user.ValidatePassword(password)) 
            return false;

        // Add the authenticated user to runtime tracking
        _runtimeUserManager.AddUser(new RuntimeUser(username));
        return true;
    }

    public void Logout(string username)
    {
        _runtimeUserManager.RemoveUser(username);
    }
}