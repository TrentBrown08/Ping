namespace Ping;

public static class ErrorType
{
    public const string ServerPrivate = "ServerPrivate";
    
    // Authentication Errors
    public const string UserTaken = "UserTaken";
    public const string UserNotFound = "UserNotFound";
    public const string PasswordMismatch = "PasswordMismatch";
}