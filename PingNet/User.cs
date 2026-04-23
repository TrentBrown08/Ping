using System.Text.Json.Serialization;
using Ping.Storage;

namespace Ping;

public class User
{
    public static User? GetUser(string username)
    {
        return Persistence.Users.FirstOrDefault(user => user.Username == username);
    }
    
    [JsonInclude]
    public string? Username { get; private init; }
    [JsonInclude]
    internal string? Password { get; private init; }

    public static User CreateUser(string username, string password)
    {
        var user = new User
        {
            Username = username,
            Password = password
        };

        Persistence.Users.Add(user);
        return user;
    }

    public static bool DeleteUser(string username, string password)
    {
        var user = GetUser(username);
        if (user?.Password != password)
            return false;
        
        Persistence.Users.Remove(user);
        return true;
    }
}