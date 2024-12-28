using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Team
{
// ### 2. **Команда** (`Teams`)
//     Хранит информацию о командах, которые участвуют в хакатонах:
//     - `Id` (Primary Key) — уникальный идентификатор команды.
//     - `Name` — название команды.
//     - `HackathonId` (Foreign Key) — внешний ключ, связывающий команду с хакатоном.
//     - `CreatedDate` — дата создания команды.
    public int Id { get; set; }
    [StringLength(20, MinimumLength = 3)]
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public int HackathonId { get; set; }
    [ForeignKey("HackathonId")]
    public Hackathon Hackathon { get; set; }
    public List<Participant> Participants { get; set; } = [];
}