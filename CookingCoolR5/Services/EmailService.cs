using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Helpers.Email;
using System.Threading.Tasks;

namespace CookingCoolR5.Services
{
    public class EmailService : IEmailService
    {
        EmailConfigModel EmailConfigModel { get; set; }
        public EmailService(EmailConfigModel emailConfigModel)
        {
            EmailConfigModel= emailConfigModel;
        }
        public async Task SendEmailAsync(string email, string subject, string message, string logsPath)
        {
            var emailHelper = new EmailHelper();
            await emailHelper.SendEmailAsync(EmailConfigModel, email, subject, message, logsPath);
        }
    }
}
