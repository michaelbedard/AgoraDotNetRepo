namespace AgoraDotNet.Core.Entities;

public class RuntimeUser
{
    public string Username { get; private set; }
    public bool IsInDuo { get; set; }    // Whether the user is in a duo
    public RuntimeUser DuoPartner { get; set; }  // The partner user
    public bool IsInGame { get; set; }

    public RuntimeUser(string username)
    {
        Username = username;
        IsInDuo = false;
        IsInGame = false;
    }
}