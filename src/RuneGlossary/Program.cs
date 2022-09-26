using RuneGlossary.Application.Performers;
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

    builder.AddPerformerFrom<TestQueryPerformer>();

    builder.AddMvcRequestReceiver()
        .UseLogger()
        .UseAuthorization();

    builder.AddRequestValidator()
        .UseFluentRequestValidator(builder => { });

    builder.AddRequestRouter(request => "resurrected", builder => builder.AddGenericHttpSender("resurrected", (options, configuration) => configuration.Bind("Services:Resurrected", options)));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("develop", builder =>
    {
        builder.WithHeaders("request-type");
        builder.SetIsOriginAllowed(origin => origin.Equals("http://localhost:5000"));
    });
});


var app = builder.Build();

app.UseDefaultExceptionHandler();

app.UseCors("develop");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGenericRequestController();

app.Run();