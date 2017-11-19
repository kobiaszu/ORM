using Formulka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Formulka.Service
{
    public class EmailService
    {
        private SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials =
                    new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")
            };
        }

        public MailMessage CreateMailMessage(Kwestio kwestio)
        {
            var BodyMessage = "from " + kwestio.Email.ToString() + ": " + kwestio.Description;
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("gym550182@gmail.com"),
                From = new MailAddress("gym550182@gmail.com"),
                To = { "kobiaszu@gmail.com" },
                Subject = kwestio.Subject,
                Body = BodyMessage,
                IsBodyHtml = true

            };
            return mailMessage;
        }

        public void SendEMail(MailMessage message)
        {
            _smtpClient.Send(message);
        }



    }
}