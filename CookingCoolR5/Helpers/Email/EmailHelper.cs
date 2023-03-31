using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace CookingCoolR5.Helpers.Email
{
    public class EmailHelper
    {
        public async Task SendEmailAsync(EmailConfigModel cnfg, string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(cnfg.FromName, cnfg.FromAddress));
            emailMessage.To.Add(new MailboxAddress("Consumer", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(cnfg.ConnectHost, cnfg.ConnectPort, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(cnfg.AuthUsername, cnfg.AuthPassword);
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
                catch(Exception ex)
                {
                    var e = ex;
                }
            }
        }
    }
}
