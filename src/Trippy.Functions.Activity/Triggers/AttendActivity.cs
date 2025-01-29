using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trippy.Functions.Activity.Triggers;

public class AttendActivity
{
    private readonly ILogger<AttendActivity> _logger;

    public AttendActivity(ILogger<AttendActivity> logger)
    {
        _logger = logger;
    }

    [Function("AttendActivity")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}