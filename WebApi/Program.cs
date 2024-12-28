using Infrastructure.Data;
using Infrastructure.Service.HackathonService;
using Infrastructure.Service.ParticipantService;
using Infrastructure.Service.TeamService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IHackathonService, HackathonService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebApp v1"));
}

app.MapControllers();
app.Run();