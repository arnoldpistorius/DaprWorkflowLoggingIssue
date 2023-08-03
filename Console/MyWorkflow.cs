using Dapr.Workflow;

namespace Console;

public class MyWorkflow : Workflow<WorkflowInput, WorkflowOutput>
{
    public override async Task<WorkflowOutput> RunAsync(WorkflowContext context, WorkflowInput input)
    {
        await context.CallActivityAsync<MyLoggingActivity>(nameof(MyLoggingActivity), input);
        return new();
    }
}