namespace CRM.HealthCheck.Application.Contracts
{
    public record LogsResponse(
        int Id,
        string Message,
        string Description,
        DateTime Time,
        string Status);
}
