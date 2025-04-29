using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.DataModels.Communications;

public class ChatParticipant : BaseDataModel
{
    public string ChatRoomId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public bool IsAdmin { get; set; }
    [Column(TypeName = "timestamp without time zone")]
    public DateTime JoinedAt { get; set; } = DateTime.Now;
}