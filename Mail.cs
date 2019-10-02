using System;
using System.Net;
using System.Net.Mail;

namespace Classes
{
    public class Mail
    {
        private string _host;
        private int _port;
        private string _username;
        private string _password;
        private string _cc;
        private string _bcc;
        private string _to;

        public Mail (string host, int port, string username, string password)
        {
            _host = host;
            _port = port;
            _username = username;
            _password = password;
        }

        public Mail CC(string cc)
        {
            _cc = cc;
            return this;
        }


        public Mail BCC(string bcc)
        {
            _bcc = bcc;
            return this;
        }

        public Mail To(string to)
        {
            _to = to;
            return this;
        }

        public bool Send (string subject, string body, bool isBodyHtml = true)
        {
            try
            {
                using (SmtpClient client = new SmtpClient (_host, _port)) {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential (_username, _password);

                    MailMessage message = new MailMessage ();
                    
                    message.From = new MailAddress(_username);
                    message.Subject = subject;
                    message.Body = body;

                    foreach (var address in _to.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.To.Add(address);    
                    }

                    foreach (var address in _cc.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.CC.Add(address);    
                    }

                    foreach (var address in _bcc.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.Bcc.Add(address);    
                    }

                    message.IsBodyHtml = isBodyHtml;

                    client.Send (message);

                    return true;
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine (erro);
                return false;
            }
        }
    }
}