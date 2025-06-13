public class EmailJobService : IEmailJobService
{
    private readonly ILogger<EmailJobService> _logger;

    public EmailJobService(ILogger<EmailJobService> logger)
    {
        _logger = logger;
    }

    public async Task SendWelcomeEmailAsync(string userEmail)
    {
        _logger.LogInformation("📧 Sending welcome email to {UserEmail}", userEmail);
        await Task.Delay(1000); 
        _logger.LogInformation("✅ Email sent to {UserEmail}", userEmail);
    }
}