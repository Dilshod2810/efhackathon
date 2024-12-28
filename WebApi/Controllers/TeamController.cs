using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Service.TeamService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TeamController(ITeamService teamService)
{
    [HttpGet]
    public async Task<Response<List<Team>>> GetAll()
    {
        return await teamService.GetAll();
    }

    [HttpGet]
    public async Task<Response<Team>> GetById(int id)
    {
        return await teamService.GetById(id);
    }
    [HttpPost]
    public async Task<Response<string>> Create(Team team)
    {
        return await teamService.Create(team);
    }
    [HttpPut]
    public async Task<Response<string>> Update(Team team)
    {
        return await teamService.Update(team);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await teamService.Delete(id);
    }
}