using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Trip.Triggers;

public class ModifyTrip
{
    private readonly ILogger<ModifyTrip> _logger;

    public ModifyTrip(ILogger<ModifyTrip> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ModifyTrip))]
    [OpenApiOperation(nameof(ModifyTrip))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "POST", "PUT", Route = "{id:int}")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You are modifying trip {id}");
    }
}