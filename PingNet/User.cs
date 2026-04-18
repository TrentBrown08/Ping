namespace Ping;

public class User
{
    public static List<User> Users = [];

    public static User? GetUser(string username)
    {
        foreach (var user in Users)
            if (user.Username == username)
                return user;
        
        return null;
    }
    
    public string? Username { get; private init; }
    internal string? Password {get; private set;}

    public static User CreateUser(string username, string password)
    {
        var user = new User
        {
            Username = username,
            Password = password
        };

        Users.Add(user);
        return user;
    }
}