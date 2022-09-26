using RuneGlossary.Resurrected.Application.Handlers;
using Serilog;
using STrain.CQS.NetCore;
using STrain.CQS.NetCore.Builders;
using STrain.CQS.NetCore.LigtInject;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLightInject();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.AddCQS(builder =>
{
    builder.AddGenericRequestHandler();
    builder.AddMvcRequestReceiver()
        .UseLogger();

    builder.AddPerformerFrom<TestQueryPerformer>();

    builder.AddRequestValidator()
        .UseFluentRequestValidator(builder => { });
});

var app = builder.Build();

app.UseDefaultExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGenericRequestController();

app.Run();