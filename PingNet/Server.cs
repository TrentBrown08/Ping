using WebSocketSharp.Server;

using Ping.Network;
using Ping.Storage;

namespace Ping;

// Global class for managing Ping Server
public static class Server
{
    internal static bool IsPrivate = false;
    internal static bool IsEncrypted = false;
    
    private static WebSocketServer? _socket;
    
    private static bool _isRunning = false;
    public static void Start(uint port = 8099, bool encryptData = false, bool isPrivate = false)
    {
        if (_isRunning)
            return;
        
        // Load persistent data
        Persistence.LoadPersistentData();

        foreach (var user in Persistence.Users)
        {
            Console.WriteLine($"Loaded user {user.Username}");
        }
        
        IsPrivate = isPrivate; 
        IsEncrypted = encryptData;
        
        _socket = new WebSocketServer("ws://localhost:" + port);
        _socket.AddWebSocketService<ServerBehavior>("/server"); //Server logic
        
        _socket.Start();
        _isRunning = true;
    }

    public static void Stop()
    {
        Save();
        
        _socket?.Stop();
        _socket = null;
        _isRunning = false;
    }

    public static void Save()
    {
        Persistence.SavePersistentData();
    }
}