
namespace CRM.HealthCheck.BusinessLogic.Service
{
    public interface ISendMailService
    {
        Task SendMailAsync(string email, string subject, string message);
    }
}