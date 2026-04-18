namespace Ping;

public class Session
{
    public static List<Session> LiveSessions { get; private set; } = [];
    
    public string? Token { get; private set; }
    public User User { get; private set; }
    
    // Used to verify messages sent by clients in every session. Refreshed when a user connects to the server.
    internal Session(User user, string sessionToken)
    {
        User = user;
        Token = sessionToken;
    }
}