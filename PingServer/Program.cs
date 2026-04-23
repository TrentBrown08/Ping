using Ping;

namespace PingServer;

internal static class Program
{
    static void Main(string[] args)
    {
        Server.Start(8099);
        
        PollEvents();
    }

    private static void PollEvents()
    {
        string? output = null;
        while (true)
        {
            // Reset console
            Console.Clear();
            if (output != null)
            {
                Console.WriteLine(output + "\n" + "===================="); 
                output = null;
            }
            
            Console.WriteLine("Input a command... (\"help\" for more info)");
            string? input = Console.ReadLine()?.ToLower();
            
            switch (input)
            {
                case "help":
                {
                    output = "Commands:" + "\n" +
                             "\"exit\": Closes the server and saves all persistent data." + "\n" +
                             "\"save\": Forces a save on all current persistent data.";
                    break;
                }
                case "exit":
                {
                    Server.Stop();
                    return;
                }
                case "save":
                {
                    Server.Save();
                    break;
                }
                case "restart":
                {
                    Server.Stop();
                    Server.Start();
                    break;
                }
                case "stat":
                {
                    output = "Server Statistics:\n" +
                             $"Number of Users: {Ping.Storage.Persistence.Users.Count}\n" +
                             $"Current Sessions: {Ping.Session.LiveSessions.Count}";
                    break;
                }
                default:
                {
                    output = $"Unknown command: \"{input}\"";
                    break;
                }
            }
        }
    }
}