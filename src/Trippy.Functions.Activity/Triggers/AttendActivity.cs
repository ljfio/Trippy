using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Activity.Triggers;

public class AttendActivity
{
    private readonly ILogger _logger;

    public AttendActivity(ILogger<AttendActivity> logger)
    {
        _logger = logger;
    }

    [Function(nameof(AttendActivity))]
    [OpenApiOperation(nameof(AttendActivity))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "POST", Route = "{id:int}/attend")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You have requested to attend activity {id}");
    }
}