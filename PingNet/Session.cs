namespace Ping;

// Used to verify messages sent by clients in every session. Refreshed when a user connects to the server.
public class Session
{
    public static List<Session> LiveSessions { get; private set; } = [];
    
    public string Token { get; private init; }
    private User _user;

    internal static Session? GetSession(string token)
    {
        return LiveSessions.FirstOrDefault(session => session.Token == token);
    }

    internal static Session? GetSession(User user)
    {
        return LiveSessions.FirstOrDefault(session => session._user == user);
    }

    internal static Session CreateSession(User user)
    {
        var token = user.GetHashCode().ToString();

        Session newSession = new()
        {
            Token = token,
            _user = user
        };
        
        LiveSessions.Add(newSession);
        Console.WriteLine($"Session created for user {user.Username}: {newSession.Token}");
        return newSession;
    }

    internal void End()
    {
        LiveSessions.Remove(this);
        Console.WriteLine($"Session ended for user {_user.Username}: {Token}");
    }
    
    internal static void EndSession(Session session)
    {
        LiveSessions.Remove(session);
    }
}