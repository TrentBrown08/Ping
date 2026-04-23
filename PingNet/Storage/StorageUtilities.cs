using System.Text.Json;

namespace Ping.Storage;

public class StorageUtilities
{
    public static void SaveData(object data, string fileName)
    {
        try
        { 
            var jsonText = JsonSerializer.Serialize(data);
            
            if (!Directory.Exists(Persistence.ServerDataPath))
                Directory.CreateDirectory(Persistence.ServerDataPath);
            
            if (!File.Exists(Path.Combine(Persistence.ServerDataPath, fileName)))
                File.Create(Path.Combine(Persistence.ServerDataPath, fileName));
            
            File.WriteAllText(Path.Combine(Persistence.ServerDataPath, fileName), jsonText);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed saving {fileName}: {e.Message}");
        }
    }

    public static T? LoadData<T>(string fileName)
    {
        try
        {
            var jsonText = File.ReadAllText(Path.Combine(Persistence.ServerDataPath, fileName));
            
            return JsonSerializer.Deserialize<T>(jsonText);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed saving {fileName}: {e.Message}");
            return default;
        }
    }
}