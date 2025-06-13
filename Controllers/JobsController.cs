using Hangfire;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    [HttpPost("enqueue")]
    public IActionResult EnqueueJob()
    {
        BackgroundJob.Enqueue(() => Console.WriteLine("Test job enqueued!"));
        return Ok("Job enqueued!");
    }
}