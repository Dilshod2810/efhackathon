using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.HackathonService;

public interface IHackathonService
{
    Task<Response<List<GetHackathonDTO>>> GetAll();
    Task<Response<Hackathon>> GetById(int id);
    Task<Response<string>> Create(Hackathon hackathon);
    Task<Response<string>> Update(Hackathon hackathon);
    Task<Response<string>> Delete(int id);
}