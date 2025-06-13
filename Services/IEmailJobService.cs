public interface IEmailJobService
{
    Task SendWelcomeEmailAsync(string userEmail);
}