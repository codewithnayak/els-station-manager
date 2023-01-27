using HttpUtility.Middlewares;
using Microsoft.EntityFrameworkCore;
using StationManagerApi.Db;
using StationManagerApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStationManagerService, StationManagerService>();

builder.Services.AddDbContext<StationDbContext>( _ => _.UseSqlServer(builder.Configuration.GetConnectionString("StationDbConnectionString")));
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

var app = builder.Build();

//add the global exception filter on top as it will wrap all other middleware .
app.AddGlobalExceptionFilter();
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
