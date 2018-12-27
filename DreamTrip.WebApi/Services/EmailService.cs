using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamTrip.WebApi.Configurations;
using DreamTrip.WebApi.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace DreamTrip.WebApi.Services
{
    public class EmailService : IEmailService
    {
        private IEmailConfiguration emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }

        public void Send(User user)
        {
            var message = new MimeMessage();
            var link = emailConfiguration.ConfirmationLink + user.Id;
            message.To.Add(new MailboxAddress($"{user.FirstName} {user.LastName}", user.Email));
            message.From.Add(new MailboxAddress("DreamTrip", emailConfiguration.SmtpUsername));

            message.Subject = "Registration confirmation";
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "<div>To confirm your registration click on following link: " + link + "<div>" +
                       "<div>If you did not try to register at our service please ignore this email<div>"
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(emailConfiguration.SmtpServer, emailConfiguration.SmtpPort, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2"); // ?

                emailClient.Authenticate(emailConfiguration.SmtpUsername, emailConfiguration.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
