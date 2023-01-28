using FluentValidation;
using FluentValidation.AspNetCore;
using HttpUtility.Middlewares;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StationManagerApi.Db;
using StationManagerApi.Services;
using StationManagerApi.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.
    AddControllers()
    .AddJsonOptions(_ => _.JsonSerializerOptions.DefaultIgnoreCondition =
     System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStationManagerService, StationManagerService>();

builder.Services.AddDbContext<StationDbContext>( _ => _.UseSqlServer(builder.Configuration.GetConnectionString("StationDbConnectionString")));
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<CreateStationValidator>();

builder.Host.UseSerilog((ctx ,config) => 
{
    /*
    if (ctx.HostingEnvironment.IsDevelopment())
    {
        config.WriteTo.Console(Serilog.Events.LogEventLevel.Debug);
    }
    else
    {
        config.WriteTo.Seq("http://localhost:80", Serilog.Events.LogEventLevel.Debug);
    }
    */
    //Change it once deployment is ready as default run is devlopment now .
    config.WriteTo.Seq("http://localhost:80", Serilog.Events.LogEventLevel.Debug);
});

var app = builder.Build();
//add the global exception filter on top as it will wrap all other middleware .
app.AddGlobalExceptionFilter();
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
