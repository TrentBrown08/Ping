using System.Text.Json;

namespace Ping.Network;

public static class MessageHelper
{
    public static string CreateMessage(string type, object message)
    {
        var dict = new Dictionary<string, object>
        {
            ["type"] = type,
            ["message"] = message
        };

        var data = JsonSerializer.Serialize(dict);
        return data;
    }
}