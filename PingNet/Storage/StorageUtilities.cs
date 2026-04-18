using System.Text.Json;

namespace Ping.Storage;

public class StorageUtilities
{
    public static void SaveData(object data, string fileName)
    {
        try
        {
            var jsonText = JsonSerializer.Serialize(data);
            
            File.WriteAllText(Path.Combine(Persistence.ServerDataPath, fileName), jsonText);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed saving {fileName}: {e.Message}");
        }
    }

    public static object? LoadData(string fileName)
    {
        try
        {
            var jsonText = File.ReadAllText(Path.Combine(Persistence.ServerDataPath, fileName));
            
            return JsonSerializer.Deserialize<object>(jsonText);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed saving {fileName}: {e.Message}");
            return null;
        }
    }
}