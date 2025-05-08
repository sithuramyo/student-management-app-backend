using Cores.Features.Faculites;
using Shares.Models.Faculties;

namespace Interfaces.Features.Faculties;

public class FacultyController(IUserFacultyService service) : BaseController
{
    [HttpGet("get-class-schedules")]
    [ProducesResponseType(typeof(ApiResponse<FacultyClassScheduleResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAcademicTerms()
    {
        var facultyId = GetCurrentUserId();
        var result = await service.GetFacultyClassSchedule(facultyId);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
}