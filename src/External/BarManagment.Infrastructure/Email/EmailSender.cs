using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using BarManagment.Application.Core.Abstractions.Email;

namespace BarManagment.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config, ILogger<EmailSender> logger)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(MailboxAddress.Parse(_config.GetSection("EmailSender").Value));
            mailMessage.Subject = subject;
            mailMessage.To.Add(MailboxAddress.Parse(email));
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };

            using (SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_config.GetSection("EmailSender").Value,
                    _config.GetSection("EmailPass").Value);
                await client.SendAsync(mailMessage);
                await client.DisconnectAsync(true);
            }

        }
    }
}
