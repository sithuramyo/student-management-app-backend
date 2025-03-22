namespace Interfaces.Features.Academics.Departments;

public class DepartmentController(IDepartmentService service) : BaseController
{
    [HttpGet]
    public async Task<ActionResult> DepartmentList([FromQuery] PaginationRequest request)
    {
        var result = await service.DepartmentListAsync(request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
}