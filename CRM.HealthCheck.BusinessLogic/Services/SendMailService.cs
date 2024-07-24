using System.Net;
using System.Net.Mail;


namespace CRM.HealthCheck.BusinessLogic.Service
{
    public class SendMailService : ISendMailService
    {
        public Task SendMailAsync(string email, string subject, string message)
        {
            // TODO: надо будет в конфиги закинуть логин и пароль

            var mail = "";
            var password = "";

            var client = new SmtpClient("", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject: subject,
                                message
                                ));
        }
    }
}
