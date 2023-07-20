using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Practice.CleanArchitecture.Application.Common.Models;
using Practice.CleanArchitecture.Application.Common.Services;
using Practice.CleanArchitecture.Infrastructure.Settings;

namespace Practice.CleanArchitecture.Infrastructure.Services;

public class SendMailService : ISendMailService
{
    private readonly ILogger<SendMailService> _logger;

    private readonly MailConfiguration _emailConfiguration;
    public SendMailService(ILogger<SendMailService> logger, IOptions<MailConfiguration> options)
    {
        _logger = logger;

        _emailConfiguration = options.Value;
    }

    public async Task SendAsync(MailContent mailContent)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailConfiguration.DisplayName, _emailConfiguration.UserName));
        message.To.Add(new MailboxAddress("Mrs. Hieu", "damchihieu94@gmail.com"));
        message.Subject = "How you doin'?";

        message.Body = new TextPart("plain")
        {
            Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
        };

        using (var client = new SmtpClient())
        {
            client.Connect(_emailConfiguration.Host, _emailConfiguration.Port, false);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);

            await client.SendAsync(message);
            client.Disconnect(true);
        }
    }
}