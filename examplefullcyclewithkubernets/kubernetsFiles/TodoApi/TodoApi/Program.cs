using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TodoApi.Database;
using TodoApi.Database.Configurations;
using TodoApi.Extensions;
using TodoApi.Middlewares;
using TodoApi.Repositories;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services;
using TodoApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextPool<TodoContext>(options =>
{
    options.UseNpgsql(DatabaseHelper.GetStringConnection(builder.Configuration));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.ConfigurationOptions = new ConfigurationOptions
    {
        EndPoints = { $"{builder.Configuration["urlRedis"]}:{builder.Configuration["portRedis"]}" },
        Password = builder.Configuration["passRedis"],
        ConnectTimeout = 5000,
        SyncTimeout = 3000,
        AsyncTimeout = 10000
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
    setupAction.ApiVersionReader = ApiVersionReader.Combine(
        new MediaTypeApiVersionReader("ver"));
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.MigrateDatabase();

app.Run();
