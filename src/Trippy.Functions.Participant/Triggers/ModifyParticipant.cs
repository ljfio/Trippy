using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Participant.Triggers;

public class ModifyParticipant
{
    private readonly ILogger<ModifyParticipant> _logger;

    public ModifyParticipant(ILogger<ModifyParticipant> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ModifyParticipant))]
    [OpenApiOperation(nameof(ModifyParticipant))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "POST", "PUT", Route = "{id:int}")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You are modifying participant {id}");
    }
}