using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Trip.Triggers;

public class GetActivities
{
    private readonly ILogger<GetActivities> _logger;

    public GetActivities(ILogger<GetActivities> logger)
    {
        _logger = logger;
    }


    [Function(nameof(GetActivities))]
    [OpenApiOperation(nameof(GetActivities))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "{id:int}/activities")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You are requesting trip {id} activities");
    }
}