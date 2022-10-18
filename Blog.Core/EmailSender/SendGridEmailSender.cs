using Blog.Core.Models.Emails;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Blog.Core.EmailSender;

public class SendGridEmailSender : IEmailSender
{
    private readonly ISendGridClient sendGridClient;
    private readonly ILogger logger;

    public SendGridEmailSender(ISendGridClient sendGridClient, ILogger<SendGridEmailSender> logger)
    {
        this.sendGridClient = sendGridClient;
        this.logger = logger;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("aspnettest1912@gmail.com", "Blog"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail,"Test"));

        var response = await sendGridClient.SendEmailAsync(msg);
        if (response.IsSuccessStatusCode)
        {
            logger.LogInformation("Email queued successfully");
        }
        else
        {
            logger.LogError("Failed to send email");
            // Adding more information related to the failed email could be helpful in debugging failure,
            // but be careful about logging PII, as it increases the chance of leaking PII
        }
    }
}