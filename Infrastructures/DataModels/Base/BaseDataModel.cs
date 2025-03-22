using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.DataModels.Base;

public class BaseDataModel
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Column(TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}