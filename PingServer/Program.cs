using Ping;

namespace PingServer;

internal static class Program
{
    static void Main(string[] args)
    {
        Server.Start(8099);
        
        Console.ReadKey();
    }
}