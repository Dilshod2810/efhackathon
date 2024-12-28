using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Service.ParticipantService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParticipantController(IParticipantService participantService)
{
    [HttpGet]
    public async Task<Response<List<Participant>>> GetAll()
    {
        return await participantService.GetAll();
    }

    [HttpPost]
    public async Task<Response<string>> Create(Participant participant)
    {
        return await participantService.Create(participant);
    }
    [HttpPut]
    public async Task<Response<string>> Update(Participant participant)
    {
        return await participantService.Update(participant);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await participantService.Delete(id);
    }
}