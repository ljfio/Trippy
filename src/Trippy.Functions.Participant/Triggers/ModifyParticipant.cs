using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trippy.Functions.Participant.Triggers;

public class ModifyParticipant
{
    private readonly ILogger<ModifyParticipant> _logger;

    public ModifyParticipant(ILogger<ModifyParticipant> logger)
    {
        _logger = logger;
    }

    [Function("ModifyParticipant")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}