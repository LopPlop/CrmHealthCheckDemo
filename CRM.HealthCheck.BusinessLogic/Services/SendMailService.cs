using System.Net;
using System.Net.Mail;


//test.csharp@yandex.ru
//csharpauthorization
//smtp.yandex.ru
namespace CRM.HealthCheck.BusinessLogic.Service
{
    public class SendMailService : ISendMailService
    {
        public async Task SendMailAsync(string email, string subject, string message)
        {
            // Настройки SMTP-сервера yandex.ru
            string smtpServer = "smtp.mail.ru"; //smpt сервер(зависит от почты отправителя)
            int smtpPort = 587; // Обычно используется порт 587 для TLS
            string smtpUsername = "ngtu.avt008@mail.ru"; //твоя почта, с которой отправляется сообщение
            string smtpPassword = "UwyyJxDZmgSgbN2kV8LT";//пароль приложения (от почты)

            //Starostaavt008

            // Создаем объект клиента SMTP
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                // Настройки аутентификации
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(email); // Укажите адрес получателя
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;

                    try
                    {
                        // Отправляем сообщение
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Сообщение успешно отправлено.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
                    }
                }
            }
            return;
        }
    }
}
