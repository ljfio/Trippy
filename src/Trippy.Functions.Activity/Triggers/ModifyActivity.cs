using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trippy.Functions.Activity.Triggers;

public class ModifyActivity
{
    private readonly ILogger<ModifyActivity> _logger;

    public ModifyActivity(ILogger<ModifyActivity> logger)
    {
        _logger = logger;
    }

    [Function("ModifyActivity")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", "put")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}