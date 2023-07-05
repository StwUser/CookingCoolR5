using System.Threading.Tasks;

namespace CookingCoolR5.Data.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message, string logsPath);
    }
}
