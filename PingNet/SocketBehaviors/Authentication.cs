using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Ping.SocketBehaviors;

public class Authentication : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        string msg = e.Data;
        Console.WriteLine($"Got message from {Context.Host}: {msg}");
        
        var data = JsonSerializer.Deserialize<Dictionary<string, string>>(msg);
        if (data == null)
            return;

        bool createUser = bool.Parse(data["createUser"]);
        string username = data["username"];
        string password = data["password"];
        
        
    }

    private void VerifyUser(bool createUser, string username, string password)
    {
        var user = User.GetUser(username);
        if (user != null && createUser)
        {
            
        }
    }
}