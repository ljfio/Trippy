using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trippy.Functions.Trip.Triggers;

public class GetActivities
{
    private readonly ILogger<GetActivities> _logger;

    public GetActivities(ILogger<GetActivities> logger)
    {
        _logger = logger;
    }

    [Function("GetActivities")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}