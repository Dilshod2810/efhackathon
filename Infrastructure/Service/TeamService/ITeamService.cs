using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.TeamService;

public interface ITeamService
{
    
    Task<Response<List<Team>>> GetAll();
    Task<Response<Team>> GetById(int id);
    Task<Response<string>> Create(Team team);
    Task<Response<string>> Update(Team team);
    Task<Response<string>> Delete(int id);
}