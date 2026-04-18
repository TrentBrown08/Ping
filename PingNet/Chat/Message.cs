namespace Ping;

public class Message
{
    public User? Sender { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string? Text { get; private set; }
}