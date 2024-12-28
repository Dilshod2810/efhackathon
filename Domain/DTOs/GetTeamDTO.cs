namespace Domain.DTOs;

public class GetTeamDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public int HackathonId { get; set; }
}