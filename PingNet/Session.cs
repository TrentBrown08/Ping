using System.Net;

namespace Ping;

// Used to verify messages sent by clients in every session. Refreshed when a user connects to the server.
public class Session
{
    public static List<Session> LiveSessions { get; private set; } = [];
    
    public string Token { get; private set; }
    private string _endpoint;
    private User _user;

    internal static Session? GetSession(string token)
    {
        return LiveSessions.FirstOrDefault(session => session.Token == token);
    }

    internal static Session? GetSession(IPAddress address)
    {
        return LiveSessions.FirstOrDefault(session => address.Equals(session._endpoint));
    }

    internal static Session? GetSession(User user)
    {
        return LiveSessions.FirstOrDefault(session => session._user == user);
    }

    internal static Session CreateSession(string endpoint, User user)
    {
        Session newSession = new();
        newSession._endpoint = endpoint;
        newSession._user = user;
        newSession.Token = Guid.NewGuid().ToString(); // Generate unique identifier for session
        
        LiveSessions.Add(newSession);
        Console.WriteLine($"Session created for user {user.Username} with endpoint {newSession._endpoint}: {newSession.Token}");
        return newSession;
    }

    internal void End()
    {
        LiveSessions.Remove(this);
        Console.WriteLine($"Session ended for user {_user.Username} from endpoint {_endpoint}: {Token}");
    }
    
    internal static void EndSession(Session session)
    {
        LiveSessions.Remove(session);
    }
}