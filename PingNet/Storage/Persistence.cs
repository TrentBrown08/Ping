using System.Threading.Channels;

namespace Ping.Storage;

public class Persistence
{
    internal static string ServerDataPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PingNet");

    // Items to be saved across instances
    public static User[] Users { get; private set; } = [];
    public static Channel[] Channels { get; private set; } = [];
    
    internal static void LoadPersistentData()
    {
        var userData = (User[]?)StorageUtilities.LoadData(Files.USERS);
        var channelData = (Channel[]?)StorageUtilities.LoadData(Files.CHANNELS);
        
        if (userData != null)
            Users = userData;
        if (channelData != null)
            Channels = channelData;
    }

    internal static void SavePersistentData()
    {
        StorageUtilities.SaveData(Users, Files.USERS);
        StorageUtilities.SaveData(Channels, Files.CHANNELS);
    }
}