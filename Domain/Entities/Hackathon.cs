using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Hackathon
{
// ### 1. **Хакатон** (`Hackathons`)
//     Хранит информацию о мероприятии:
//     - `Id` (Primary Key) — уникальный идентификатор хакатона.
//     - `Name` — название хакатона.
//     - `Date` — дата проведения хакатона.
//     - `Theme` — тема хакатона.
    public int Id { get; set; }
    [MaxLength(30)] 
    [Required]
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    [StringLength(50, MinimumLength = 3)]
    public string Theme { get; set; }
    public List<Team> Teams { get; set; } = [];
}