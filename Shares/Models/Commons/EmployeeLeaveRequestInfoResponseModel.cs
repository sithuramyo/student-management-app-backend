namespace Shares.Models.Commons;

public class EmployeeLeaveRequestInfoResponseModel
{
    public List<EmployeeLeaveRequestInfo> EmployeeLeaveRequestInfos { get; set; } = [];
}

public class EmployeeLeaveRequestInfo
{
    public string Id { get; set; }
    public string LeaveName { get; set; }
    public string Description { get; set; }
    public string TypicalDays { get; set; }
}