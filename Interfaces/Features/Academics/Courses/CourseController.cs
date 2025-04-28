using Cores.Features.Academics.Courses;
using Shares.Models.Academics.Courses;
namespace Interfaces.Features.Academics.Courses;

public class CourseController(ICourseService service) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PaginationResponse<CourseResponseModel>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> List([FromQuery] PaginationRequest request)
    {
        var result = await service.ListAsync(request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(ApiRequest<CreateCourseRequestModel> request)
    {
        var result = await service.CreateAsync(request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<CourseResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetById(string id)
    {
        var result = await service.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(string id, ApiRequest<UpdateCourseRequestModel> request)
    {
        var result = await service.UpdateAsync(id, request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Delete(string id)
    {
        var result = await service.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
}