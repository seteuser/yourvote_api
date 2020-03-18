using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Service.Services.Common
{
    public static class EmailCommon
    {
        public static string Email => ConfigurationManager.AppSettings["EMAIL"];
        public static string Password => ConfigurationManager.AppSettings["PASSWORD"];
        public static string Port => ConfigurationManager.AppSettings["PORT"];
        public static string Host => ConfigurationManager.AppSettings["HOST"];

        public static void Send(string body, string subject, Session session)
        {
            var client = SmtpClient();
            var mail = new MailMessage
            {
                From = new MailAddress(Email),
                Subject = subject,
                IsBodyHtml = true,
                Body = body,
                BodyEncoding = Encoding.UTF8,
                Priority = MailPriority.High,
               // To = { },
            };
            client.Send(mail);
        }


        public static void Send(string body, string subject, User user)
        {
            var client = SmtpClient();
            var mail = new MailMessage
            {
                From = new MailAddress(Email),
                Subject = subject,
                IsBodyHtml = true,
                Body = body,
                BodyEncoding = Encoding.UTF8,
                Priority = MailPriority.High,
                To = { new MailAddress(user.Email, user.FirstName) },
            };
            client.Send(mail);
        }
        private static SmtpClient SmtpClient()
        {
            var client = new SmtpClient
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Email, Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = Host,
                Port = int.Parse(Port)
            };
            return client;
        }
    }
}
