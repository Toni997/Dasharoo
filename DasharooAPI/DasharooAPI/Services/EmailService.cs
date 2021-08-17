using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace DasharooAPI.Services
{
    public class EmailService : IMessageService
    {
        public async Task SendAsync(MessageToSend message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("no-reply@dasharoo.com"));
            email.To.Add(new MailboxAddress(message.Destination));
            email.Subject = message.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message.Body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("tkazinoti@hrcloud.com", "eypzgwnklnkmnxqm");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
