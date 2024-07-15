namespace CRM.HealthCheck.Application.Contracts
{
    public record LogsRequest(
        string Message,
        string Description,
        DateTime Time,
        string Status);
}
