using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.ParticipantService;

public interface IParticipantService
{
    Task<Response<List<Participant>>> GetAll();
    Task<Response<string>> Create(Participant participant);
    Task<Response<string>> Update(Participant participant);
    Task<Response<string>> Delete(int id);
}