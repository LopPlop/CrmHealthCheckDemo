using CRM.HealthCheck.Application.HealthCheck;
using CRM.HealthCheck.BusinessLogic.Service;
using CRM.HealthCheck.DataAccess;
using CRM.HealthCheck.DataAccess.Repository;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration.GetConnectionString(nameof(CRMHealthCheckDbContext));

builder.Services.AddDbContext<CRMHealthCheckDbContext>(
    options =>
    {
        options.UseSqlServer(ConnectionString);
    });

builder.Services.AddScoped<ILogsRepository, LogsRepository>();
builder.Services.AddScoped<ILogService, LogService>();


builder.Services.AddHealthChecks()
    .AddSqlServer(ConnectionString, name: "SqlServerHeclthCheck")
    .AddCheck<CRMHealthCheck>(nameof(CRMHealthCheck))
    .AddDbContextCheck<CRMHealthCheckDbContext>();

builder.Services
    .AddHealthChecksUI(setup =>
    {
        setup.UseApiEndpointHttpMessageHandler(sp =>
        {
            return new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };
        });
        setup.AddHealthCheckEndpoint("Healthcheck API", "/healthcheck");
    })
    .AddInMemoryStorage();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Маршруты для HealthChecks
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
    },
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecks("/healthcheck", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});


// Маршрут для Dashboard HealthCheckUI
app.MapHealthChecksUI(options => options.UIPath = "/dashboard");

app.Run();
