using System.Threading.Channels;

namespace Ping.Storage;

public class Persistence
{
    internal static string ServerDataPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PingNet");

    // Items to be saved across instances
    public static List<User> Users { get; private set; } = [];
    public static List<Channel> Channels { get; private set; } = [];
    
    internal static void LoadPersistentData()
    {
        var userData = StorageUtilities.LoadData<List<User>>(Files.Users);
        var channelData = StorageUtilities.LoadData<List<Channel>>(Files.Channels);
        
        if (userData != null)
            Users = userData.ToList();
        
        if (channelData != null)
            Channels = channelData.ToList();
    }

    internal static void SavePersistentData()
    {
        StorageUtilities.SaveData(Users, Files.Users);
        StorageUtilities.SaveData(Channels, Files.Channels);
    }
}