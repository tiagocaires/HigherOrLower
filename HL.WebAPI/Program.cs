using HL.Data;
using HL.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GameNewRequestNew));

builder.Services.AddAutoMapper(typeof(GameNewRequestNew));

builder.Services.AddDbContext<HLContext>(opt => opt.UseInMemoryDatabase("higher-or-lower-db"));

builder.Services.AddScoped<IGameService, GameService>()
                .AddScoped<IPlayerGameService, PlayerGameService>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddScoped<IStepAnswerService, StepAnswerService>()
                .AddScoped<IStepService, StepService>();

var app = builder.Build();

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
