using System.ComponentModel.DataAnnotations;

namespace Infrastructures.DataModels.Leaves;

public class EmployeeLeaveInfo
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string LeaveName { get; set; } = null!;
    public int LeaveType { get; set; }
    public string Description { get; set; } = null!;
    public string TypicalDays { get; set; } = null!;
}