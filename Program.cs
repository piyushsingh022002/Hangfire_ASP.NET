using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Configure Hangfire with PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config =>
    config.UsePostgreSqlStorage(c =>
        c.UseNpgsqlConnection(connectionString)));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Enable Hangfire Dashboard
app.UseHangfireDashboard();
app.MapHangfireDashboard();

// Example background job
//Fire and Forget Job
BackgroundJob.Enqueue(() => Console.WriteLine("Hello from Hangfire!"));

app.Run();