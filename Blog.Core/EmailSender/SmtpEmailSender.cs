using Blog.Core.Models.Emails;
using MailKit.Net.Smtp;
using MimeKit;

namespace Blog.Core.EmailSender;

public class SmtpEmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    public SmtpEmailSender(EmailConfiguration emailConfig)
    {
        this._emailConfig = emailConfig;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse(this._emailConfig.UserName));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = subject;
        message.Body = new TextPart
        {
            Text = body
        };

        await SendAsync(message);
    }
    private async Task SendAsync(MimeMessage message)
    {
        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(this._emailConfig.SmtpServer, this._emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(this._emailConfig.From, this._emailConfig.Password);
            await client.SendAsync(message);


        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}
