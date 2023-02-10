using CompStore.Data;
using CompStore.Service.Services.Interfaces;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompStore.Service.Services.Implementations
{

    public class EmailServices : IEmailServices
    {
        private readonly DataContext _context;

        public EmailServices(DataContext context)
        {
            _context = context;
        }
        public void Send(string to, string subject, string html)
        {
            var context = _context.EmailSettings.FirstOrDefault(x => x.Id == 1);

            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(context.SmtpEmail));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(context.SmtpHost, context.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(context.SmtpEmail, context.SmtpPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
