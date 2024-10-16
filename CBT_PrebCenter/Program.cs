using CBTPreparation.APIs.Extensions;
using CBTPreparation.APIs.Middlewares;
using CBTPreparation.Application.Handlers;
using CBTPreparation_Infrastructure.Extensions;
using CBTPreparation.Application;
using Hangfire;
using CBTPreparation.Infrastructure.BackgroundJobService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureValidator();
builder.Services.AddJWTAuth(builder.Configuration);
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureMapster();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddEndpoints();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddTransient<AuthenticationDelegatingHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// Add Hangfire Dashboard middleware and start the Hangfire server
app.UseHangfireDashboard("/hangfire");

app.UseHangfireServer();


app.MapEndpoints();

using (var scope = app.Services.CreateScope())
{
    CancellationToken token = new();
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    var questionBackgroundService = scope.ServiceProvider.GetRequiredService<QuestionBackgroundService>();

    recurringJobManager.AddOrUpdate(
        "monthly-question-update",
        () => questionBackgroundService.FetchAndProcessQuestions(token),
        Cron.Minutely);
}

app.Run();
