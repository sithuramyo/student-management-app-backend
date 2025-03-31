namespace Shares.Models.Commons;

public class DepartmentsResponseModel
{
    public List<Departments> Departments { get; set; } = [];
}

public class Departments
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}