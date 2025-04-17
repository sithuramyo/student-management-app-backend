namespace Shares.Models.Commons;

public class FacultiesResponseModel
{
    public List<Faculty> Faculties { get; set; } = [];
}

public class Faculty
{
    public string Id { get; set; }
    public string Name { get; set; }
}