namespace Practice.CleanArchitecture.Infrastructure.Settings;

public class MailConfiguration
{
    public string? UserName { get; set; }
    public string? DisplayName { get; set; }
    public string? Password { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
}