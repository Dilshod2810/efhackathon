using System.Net;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.HackathonService;

public class HackathonService(DataContext context):IHackathonService
{
    public async Task<Response<List<GetHackathonDTO>>> GetAll()
    {
        var hack = await context.Hackathons.Include(h=>h.Teams).ToListAsync();
        var hackDtos = hack.Select(h => new GetHackathonDTO()
        {
            Id = h.Id,
            Name = h.Name,
            Date = h.Date,
            Theme = h.Theme,
            Teams = h.Teams.Select(t => new GetTeamDTO()
            {
                Id = t.Id,
                Name = t.Name,
                CreatedDate = t.CreatedDate,
                HackathonId = t.HackathonId
            }).ToList()
        }).ToList();
        return new Response<List<GetHackathonDTO>>(hackDtos);
    }

    public async Task<Response<Hackathon>> GetById(int id)
    {
        var hack = await context.Hackathons.FirstOrDefaultAsync(h => h.Id == id);
        return hack == null
            ? new Response<Hackathon>(HttpStatusCode.NotFound, "Not Found")
            : new Response<Hackathon>(hack);
    }

    public async Task<Response<string>> Create(Hackathon hackathon)
    {
        await context.Hackathons.AddAsync(hackathon);
        var hack = await context.SaveChangesAsync();
        return hack == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Created");

    }

    public async Task<Response<string>> Update(Hackathon hackathon)
    {
        var exisHack=await context.Hackathons.FirstOrDefaultAsync(h=>h.Id==hackathon.Id);
        if (exisHack == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        }

        exisHack.Date = hackathon.Date;
        exisHack.Name = hackathon.Name;
        exisHack.Theme = hackathon.Theme;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Updated");
    }

    public async Task<Response<string>> Delete(int id)
    {
        var exisHack = await context.Hackathons.FirstOrDefaultAsync(h=>h.Id == id);
        if (exisHack == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        }
        context.Hackathons.Remove(exisHack);
        var res=await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Deleted");
    }
}