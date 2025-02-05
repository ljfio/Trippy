using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Trippy.Functions.Activity.Triggers;

public class ModifyActivity
{
    private readonly ILogger<ModifyActivity> _logger;

    public ModifyActivity(ILogger<ModifyActivity> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ModifyActivity))]
    [OpenApiOperation(nameof(ModifyActivity))]
    [OpenApiParameter(nameof(id), Type = typeof(int), In = ParameterLocation.Path, Required = true)]
    [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
    [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "POST", "PUT", Route = "{id:int}")]
        HttpRequest req,
        int id)
    {
        return new OkObjectResult($"You are modifying activity {id}");
    }
}