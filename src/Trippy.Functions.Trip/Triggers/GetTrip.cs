using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trippy.Functions.Trip.Triggers;

public class GetTrip
{
    private readonly ILogger<GetTrip> _logger;

    public GetTrip(ILogger<GetTrip> logger)
    {
        _logger = logger;
    }

    [Function("GetTrip")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}