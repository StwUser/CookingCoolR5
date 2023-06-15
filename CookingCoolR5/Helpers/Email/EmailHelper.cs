using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace CookingCoolR5.Helpers.Email
{
    public class EmailHelper
    {
        public async Task SendEmailAsync(EmailConfigModel cnfg, string email, string subject, string message)
        {
            using (var client = new SmtpClient())
            {
                client.Host = cnfg.ConnectHost;
                client.Port = cnfg.ConnectPort;
                client.EnableSsl = cnfg.ConnectUseSsl;
                client.Credentials = new NetworkCredential(cnfg.AuthUsername, cnfg.AuthPassword);

                using var emailMessage = new MailMessage();

                emailMessage.From = new MailAddress(cnfg.FromAddress, cnfg.FromName);
                emailMessage.To.Add(new MailAddress(email));
                emailMessage.Subject = subject;
                emailMessage.Body = message;

                try
                {
                    client.Send(emailMessage);
                }
                catch(Exception ex)
                {
                    var e = ex;
                }
            }
        }
    }
}
