using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Trip.Triggers;

public class GetTrip
{
    private readonly ILogger<GetTrip> _logger;

    public GetTrip(ILogger<GetTrip> logger)
    {
        _logger = logger;
    }


    [Function(nameof(GetTrip))]
    [OpenApiOperation(nameof(GetTrip))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "{id:int}")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You are requesting trip {id}");
    }
}