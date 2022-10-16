
namespace Blog.Core.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
