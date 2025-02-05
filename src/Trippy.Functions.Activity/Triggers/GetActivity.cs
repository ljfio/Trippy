using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Activity.Triggers;

public class GetActivity
{
    private readonly ILogger _logger;

    public GetActivity(ILogger<GetActivity> logger)
    {
        _logger = logger;
    }

    [Function(nameof(GetActivity))]
    [OpenApiOperation(nameof(GetActivity))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "{id:int}")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You have requested activity {id}");
    }
}