using Cores.Features.Commons;
using Shares.Models.Commons;

namespace Interfaces.Features.Commons;

[Authorize]
public class CommonController(ICommonService service) : BaseController
{
    [HttpGet("departments")]
    [ProducesResponseType(typeof(ApiResponse<DepartmentsResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartments()
    {
        var result = await service.GetDepartmentsAsync();
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("courses")]
    [ProducesResponseType(typeof(ApiResponse<CoursesResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourses()
    {
        var result = await service.GetCoursesAsync();
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
    
    [HttpGet("prerequisites")]
    [ProducesResponseType(typeof(ApiResponse<PrerequisiteResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPrerequisites()
    {
        var result = await service.GetPrerequisitesAsync();
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
    
}