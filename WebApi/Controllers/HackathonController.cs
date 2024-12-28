using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Service.HackathonService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HackathonController(IHackathonService hackathonService)
{
    [HttpGet]
    public async Task<Response<List<GetHackathonDTO>>> GetAll()
    {
        return await hackathonService.GetAll();
    }

    [HttpGet]
    public async Task<Response<Hackathon>> GetById(int id)
    {
        return await hackathonService.GetById(id);
    }
    [HttpPost]
    public async Task<Response<string>> Create(Hackathon hackathon)
    {
        return await hackathonService.Create(hackathon);
    }
    [HttpPut]
    public async Task<Response<string>> Update(Hackathon hackathon)
    {
        return await hackathonService.Update(hackathon);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await hackathonService.Delete(id);
    }
}