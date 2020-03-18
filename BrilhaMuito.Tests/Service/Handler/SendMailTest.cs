using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Domain.Account.Events.UserEvents;
using BrilhaMuito.Service.Handlers.Account;
using NUnit.Framework;

namespace BrilhaMuito.Tests.Service.Handler
{
    [TestFixture]
    public class SendMailTest
    {
        [Test]
        public void User_Should_Be_Received_Email_Welcome()
        {
            var newPassWord = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            var user = new User(Guid.NewGuid(), "William", "Souza", "william.m.souza@live.com", newPassWord,
                string.Empty, true);

            var onForgot = new OnWelcomeUserHandler();
            onForgot.Handler(new OnWelcomeUserEvent(user, newPassWord));
        }

        [Test]
        public void User_Should_Be_Received_Forgot_Email()
        {
            var newPassWord = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            var user = new User(Guid.NewGuid(), "William", "Souza", "william.m.souza@live.com", newPassWord,
                string.Empty, true);
            var onForgot = new OnForgotUserHandler();
            onForgot.Handler(new OnForgotUserEvent(user, newPassWord));
        }

        public static string Email => ConfigurationManager.AppSettings["EMAIL"];
        public static string Password => ConfigurationManager.AppSettings["PASSWORD"];
        public static string Port => ConfigurationManager.AppSettings["PORT"];
        public static string Host => ConfigurationManager.AppSettings["HOST"];

        [Test]
        public void Test_SMTP()
        {
            var client = new SmtpClient()
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Email, Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = int.Parse(Port),
                Host = Host
            };

            var mail = new MailMessage
            {
                From = new MailAddress(Email),
                Subject = "Ola",
                IsBodyHtml = true,
                Body = "Enviado com Teste Unitario!",
                BodyEncoding = Encoding.UTF8,
                Priority = MailPriority.High,
                To = { new MailAddress("william.m.souza@live.com", "William") }
            };
            client.Send(mail);
        }

    }
}