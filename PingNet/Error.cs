namespace Ping;

public enum Error
{
    ServerPrivate, // User tried to connect to a private server while unverified
    UserTaken, // User tried to create an account but the username was taken
    
    
}