﻿using Blog.Core.EmailSender;
using Blog.Core.Models.Emails;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Blog.Core.Services;

public class SendGridEmailSender : IEmailSender
{
    private readonly ILogger _logger;

    public SendGridEmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<SendGridEmailSender> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; } 

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            throw new Exception("Null SendGridKey");
        }
        await Execute(Options.SendGridKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("Joe@contoso.com", "Password Recovery"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail));

        // Disable click tracking.
        // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        msg.SetClickTracking(false, false);
        var response = await client.SendEmailAsync(msg);
        //_logger.LogInformation(response.IsSuccessStatusCode
        //                       ? $"Email to {toEmail} queued successfully!"
        //                       : $"Failure Email to {toEmail}");
    }
}