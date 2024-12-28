using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Participant
{
// ### 3. **Участник** (`Participants`)
//     Хранит данные об участниках команд:
//     - `Id` (Primary Key) — уникальный идентификатор участника.
//     - `Name` — имя участника.
//     - `Email` — электронная почта участника.
//     - `TeamId` (Foreign Key) — внешний ключ, связывающий участника с командой.
//     - `Role` — роль участника в команде (например, разработчик, дизайнер, менеджер).
//         - `JoinedDate` — дата присоединения к команде.
    public int Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public Role Role { get; set; }
    public DateTime JoinedDate { get; set; }
    public int TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
}