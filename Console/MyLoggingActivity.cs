using System.Text.Json.Serialization;
using Dapr.Workflow;

namespace Console;

public class MyLoggingActivity : WorkflowActivity<WorkflowInput, WorkflowOutput>
{
    private readonly ILogger<MyLoggingActivity> logger;

    public MyLoggingActivity(ILogger<MyLoggingActivity> logger)
    {
        this.logger = logger;
    }

    [JsonConstructor]
    public MyLoggingActivity()
    {
        logger = null!;
    }

    public override Task<WorkflowOutput> RunAsync(WorkflowActivityContext context, WorkflowInput input)
    {
        logger.LogInformation(input.Message);
        return Task.FromResult<WorkflowOutput>(new());
    }
}