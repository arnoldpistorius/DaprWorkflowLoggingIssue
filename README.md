# README
This solution demonstrates the following error when using ILoggerFactory in a DAPR workflow:

```txt
Workflow failed: System.InvalidOperationException: Each parameter in the deserialization constructor on type 'Console.MyLoggingActivity' must bind to an object property or field on deserialization. Each parameter name must match with a property or field on the object. Fields are only considered when 'JsonSerializerOptions.IncludeFields' is enabled. The match can be case-insensitive.
```

## How to run?
1. Ensure .NET 7 SDK is installed
2. Run following command in this directory:
```bash
dapr run --app-port 5555 --app-id testapp -- dotnet run --project Console --urls http://+:5555
```
3. Open a browser and navigate to http://localhost:5555/start
4. Notice the error is appearing in the browser and console