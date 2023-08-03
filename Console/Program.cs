using Console;
using Dapr.Client;
using Dapr.Workflow;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddLogging(x => x.AddConsole());
services.AddDaprClient();
services.AddDaprWorkflow(x =>
{
    x.RegisterWorkflow<MyWorkflow>();
    x.RegisterActivity<MyLoggingActivity>();
});

var app = builder.Build();
app.MapGet("/start", async ([FromServices] DaprClient daprClient, [FromServices] ILogger<Program> logger) =>
{
    try
    {
        logger.LogInformation("Starting workflow...");
        var workflowInput = new WorkflowInput("Hello world!");
        var response =
            await daprClient.StartWorkflowAsync("dapr", nameof(MyWorkflow), Guid.NewGuid().ToString(), workflowInput);
        var output = await daprClient.WaitForWorkflowCompletionAsync(response.InstanceId, "dapr");
        if (output.RuntimeStatus == WorkflowRuntimeStatus.Failed)
        {
            var message = $"Workflow failed: {output.FailureDetails}";
            logger.LogError(message);
            return message;
        }

        return "OK";
    }
    catch (Exception ex)
    {
        var message = "Error starting workflow";
        logger.LogError(ex, message);
        return message;
    }
});

await app.RunAsync();