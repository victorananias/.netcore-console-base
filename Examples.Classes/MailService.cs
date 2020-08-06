using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

namespace Examples.Classes
{
    public interface IMailService
    {
        MailService BCC(string bcc);
        MailService CC(string cc);
        MailService From(string from, string fromName = null);
        MailService Login(string username, string password);
        void Send(string subject, string body, bool isBodyHtml = true);
        MailService To(string to);
    }
    public class MailSettings
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public int Port { get; set; }
    }

    public class MailService : IMailService
    {
        private string _host;
        private int _port;
        private string _cc;
        private string _bcc;
        private string _to;
        private MailAddress _from;
        private NetworkCredential _credentials;
        private ILogger<IMailService> _logger;

        public MailService(ILogger<IMailService> logger, MailSettings settings)
        {
            _logger = logger;
            _host = settings.Host;
            _port = settings.Port;
            From(settings.From);
            Login(settings.Username, settings.Password);
        }

        public MailService Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                _credentials = new NetworkCredential(username, password);
            }

            return this;
        }

        public MailService From(string from, string fromName = null)
        {
            if (from != null)
            {
                _from = new MailAddress(from, fromName);
            }

            return this;
        }

        public MailService CC(string cc)
        {
            _cc = cc;
            return this;
        }

        public MailService BCC(string bcc)
        {
            _bcc = bcc;
            return this;
        }

        public MailService To(string to)
        {
            _to = to;
            return this;
        }

        public void Send(string subject, string body, bool isBodyHtml = true)
        {
            try
            {
                using var client = new SmtpClient(_host, _port)
                {
                    EnableSsl = true,
                    Credentials = _credentials
                };

                var message = new MailMessage
                {
                    From = _from,
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml
                };

                AddAdress(message.To, _to);
                AddAdress(message.CC, _cc);
                AddAdress(message.Bcc, _bcc);

                client.Send(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                _logger.LogError("from: {0}, cc: {1}, bcc: {2}, to: {3}", _from.Address, _cc, _bcc, _to);
                throw new SmtpException("Erro ao enviar email.");
            }
        }

        private static void AddAdress(MailAddressCollection mail, string adresses)
        {
            if (string.IsNullOrEmpty(adresses))
            {
                return;
            }

            foreach (var address in adresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mail.Add(address);
            }
        }
    }
}