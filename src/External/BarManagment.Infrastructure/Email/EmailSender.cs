using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using BarManagment.Application.Core.Abstractions.Email;
using Microsoft.Extensions.Options;

namespace BarManagment.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SmtpOptions> _options;

        public EmailSender(IOptions<SmtpOptions> options)
        {
            _options = options;
        }


        public async Task SendEmailAsync(string destinationEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_options.Value.SmtpUsername, _options.Value.SmtpUser));
            message.To.Add(MailboxAddress.Parse(destinationEmail));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_options.Value.SmtpHost, _options.Value.SmtpPort,
                    SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(_options.Value.SmtpUser, _options.Value.SmtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
