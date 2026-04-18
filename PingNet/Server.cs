using WebSocketSharp.Server;

using Ping.SocketBehaviors;
using Ping.Storage;

namespace Ping;

public static class Server
{
    internal static bool IsPrivate = false;
    internal static bool IsEncrypted = false;
    
    private static WebSocketServer? _socket;

    public static void Start(uint port = 8099, bool encryptData = false, bool isPrivate = false)
    {
        Console.WriteLine(Persistence.ServerDataPath);
        
        IsPrivate = isPrivate; 
        IsEncrypted = encryptData;
        
        _socket = new WebSocketServer("ws://localhost:" + port);
        _socket.AddWebSocketService<Authentication>("/Auth"); //Authentication
        
        _socket.Start();
    }
}