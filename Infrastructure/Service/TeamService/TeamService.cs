using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.TeamService;

public class TeamService(DataContext context):ITeamService
{
    public async Task<Response<List<Team>>> GetAll()
    {
        var hack = await context.Teams.ToListAsync();
        return new Response<List<Team>>(hack);
    }

    public async Task<Response<Team>> GetById(int id)
    {
        var hack = await context.Teams.FirstOrDefaultAsync(h => h.Id == id);
        return hack == null
            ? new Response<Team>(HttpStatusCode.NotFound, "Not Found")
            : new Response<Team>(hack);
    }

    public async Task<Response<string>> Create(Team team)
    {
        await context.Teams.AddAsync(team);
        var hack = await context.SaveChangesAsync();
        return hack == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Created");

    }

    public async Task<Response<string>> Update(Team team)
    {
        var exisTeam=await context.Teams.FirstOrDefaultAsync(t=>t.Id==team.Id);
        if (exisTeam == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        }

        exisTeam.Hackathon = team.Hackathon;
        exisTeam.Name = team.Name;
        exisTeam.CreatedDate=team.CreatedDate;
        exisTeam.HackathonId = team.HackathonId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Updated");
    }

    public async Task<Response<string>> Delete(int id)
    {
        var exisTeam = await context.Teams.FirstOrDefaultAsync(t=>t.Id == id);
        if (exisTeam == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        }
        context.Teams.Remove(exisTeam);
        var res=await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Deleted");
    }
}