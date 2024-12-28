using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.ParticipantService;

public class ParticipantService(DataContext context):IParticipantService
{
    public async Task<Response<List<Participant>>> GetAll()
    {
        var part = await context.Participants.ToListAsync();
        return new Response<List<Participant>>(part);
    }

    public async Task<Response<string>> Create(Participant participant)
    {
        await context.Participants.AddAsync(participant);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server error")
            : new Response<string>("Created");
    }

    public async Task<Response<string>> Update(Participant participant)
    {
        var exisPart = await context.Participants.FirstOrDefaultAsync(p => p.Id == participant.Id);
        if (exisPart == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        }
        exisPart.Email=participant.Email;
        exisPart.Role=participant.Role;
        exisPart.Team=participant.Team;
        exisPart.JoinedDate = participant.JoinedDate;
        exisPart.TeamId=participant.TeamId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Updated");
    }

    public async Task<Response<string>> Delete(int id)
    {
        var exisPart = await context.Participants.FirstOrDefaultAsync(p => p.Id == id);
        if (exisPart == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        }
        context.Participants.Remove(exisPart);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Server Error")
            : new Response<string>("Deleted");
    }
}