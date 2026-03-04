using LeaveFlow.Application;

// CONCEPT: Minimal API with health check
// PATTERN: Walking Skeleton - thin end-to-end slice
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "LeaveFlow is alive");
app.MapGet("/health", () => new HealthResponse("healthy", DateTime.UtcNow));

app.Run();