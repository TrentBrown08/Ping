namespace Ping;

public class Channel
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public Message[]? Messages { get; private set; }
}