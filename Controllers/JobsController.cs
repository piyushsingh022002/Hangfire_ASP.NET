using Hangfire;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    [HttpPost("enqueue")]
    public IActionResult EnqueueJob()
    {
        //Fire and Forget jobs
        BackgroundJob.Enqueue(() => Console.WriteLine("Test job enqueued!"));
        return Ok("Job enqueued!");
    }

    [HttpPost("delayed")]
    public IActionResult ScheduleDelayedJob()
    {
        //Delayed Jobs 
        BackgroundJob.Schedule(() => Console.WriteLine("⏰ Delayed job ran!"), TimeSpan.FromSeconds(15));
        return Ok("Delayed job scheduled for 15s later.");
    }
    [HttpPost("recurring")]
    public IActionResult RegisterRecurringJob()
    {
        //Recurring Jobs 
        RecurringJob.AddOrUpdate("say-hello", () => Console.WriteLine("Recurring Hello!"), Cron.Minutely);
        return Ok("Recurring job scheduled to run every minute.");
    }

    [HttpPost("chained")]
    public IActionResult ChainedJob()
    {
        //Continuation jobs 
        var id = BackgroundJob.Enqueue(() => Console.WriteLine("🔗 First job"));
        BackgroundJob.ContinueJobWith(id, () => Console.WriteLine("🔗 Second job after first"));
        return Ok("Chained job executed.");
    }



}