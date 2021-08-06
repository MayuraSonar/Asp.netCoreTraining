using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            _emailOptions = options.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return SendNotifcation(_emailOptions.SendGridKey, subject, htmlMessage, email);
        }


        public async Task SendNotifcation(string sendGridKey,string subject,string htmlMessage,string email)
        {
            var client = new SendGridClient(sendGridKey);
            var from = new EmailAddress("mayura.sonar@outlook.com", "CandyShopTraining");
            var to = new EmailAddress(email);

            //var subject = "Hello world email from Sendgrid ";
            //var htmlContent = "<strong>Hello world with HTML content</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
