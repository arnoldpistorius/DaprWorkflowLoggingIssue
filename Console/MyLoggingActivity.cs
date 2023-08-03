using Dapr.Workflow;

namespace Console;

public class MyLoggingActivity : WorkflowActivity<WorkflowInput, WorkflowOutput>
{
    private readonly ILogger<MyLoggingActivity> logger;

    public MyLoggingActivity(ILoggerFactory loggerFactory)
    {
        logger = loggerFactory.CreateLogger<MyLoggingActivity>();
    }
    
    public override Task<WorkflowOutput> RunAsync(WorkflowActivityContext context, WorkflowInput input)
    {
        logger.LogError(input.Message);
        return Task.FromResult<WorkflowOutput>(new());
    }
}