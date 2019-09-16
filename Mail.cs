using System;
using System.Net;
using System.Net.Mail;

namespace Classes
{
    class Mail
    {
        private string _host;
        private int _port;
        private string _username;
        private string _password;

        public Mail (string host, int port, string username, string password)
        {
            _host = host;
            _port = port;
            _username = username;
            _password = password;
        }

        public bool Send (string from, string to, string subject, string textMessage)
        {
            try
            {
                using (SmtpClient client = new SmtpClient (_host, _port)) {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential (_username, _password);

                    MailMessage message = new MailMessage (
                        from,
                        to,
                        subject,
                        textMessage
                    );

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