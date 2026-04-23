using System.Text.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Ping.Network;

// Used to handle connection, creation, and messages for client to server logic
public class ServerBehavior : WebSocketBehavior
{
    private Session _session;
    
    // Handle an incoming JSON message
    protected override void OnMessage(MessageEventArgs e)
    {
        var data = JsonSerializer.Deserialize<Dictionary<string, string?>>(e.Data);

        if (data == null)
            return;
        
        var messageType = data["type"];
        
        switch (messageType)
        {
            case MessageType.CreateUser:
            {
                var username = data["username"];
                var password = data["password"];

                if (username == null || password == null)
                {
                    Send(MessageHelper.CreateMessage(MessageType.Error, "Null username or password"));
                    return;
                }
                
                CreateUser(username, password);
                break;   
            }

            case MessageType.Login:
            {
                var username = data["username"];
                var password = data["password"];

                if (username == null || password == null)
                {
                    Send(MessageHelper.CreateMessage(MessageType.Error, "Null username or password"));
                    return;
                }

                Login(username, password);
                break;
            }

            default:
            {
                Console.WriteLine($"Unknown message type: {messageType}");
                break;
            }
        }
    }

    protected override void OnClose(CloseEventArgs e)
    {
        _session?.End();
    }
    
    private void CreateUser(string username, string password)
    {
        Console.WriteLine($"Creating user: {username}");
        
        var user = User.GetUser(username);

        if (user != null)
        {
            Send(MessageHelper.CreateMessage(MessageType.Error, ErrorType.UserTaken));
            return;
        }
        
        // Todo: Verify security of password
        
        // Create new User and apply session token
        user = User.CreateUser(username, password);
        _session = Session.CreateSession(user);
        
        Send(MessageHelper.CreateMessage(MessageType.Login, _session.Token));
    }

    private void Login(string username, string password)
    {
        var user = User.GetUser(username);
        
        if (user == null)
        {
            Send(MessageHelper.CreateMessage(MessageType.Error, ErrorType.UserNotFound));
            return;
        }

        if (user.Password != password)
        {
            Send(MessageHelper.CreateMessage(MessageType.Error, ErrorType.PasswordMismatch));
            return;
        }
        
        _session = Session.CreateSession(user);
        Send(MessageHelper.CreateMessage(MessageType.Login, _session.Token));
    }
}