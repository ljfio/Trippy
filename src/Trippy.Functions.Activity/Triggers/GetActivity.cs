using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trippy.Functions.Activity.Triggers;

public class GetActivity
{
    private readonly ILogger<GetActivity> _logger;

    public GetActivity(ILogger<GetActivity> logger)
    {
        _logger = logger;
    }

    [Function("GetActivity")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}