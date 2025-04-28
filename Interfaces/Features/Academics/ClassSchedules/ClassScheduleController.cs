using Cores.Features.Academics.ClassSchedules;
using Shares.Models.Academics.ClassSchedules;

namespace Interfaces.Features.Academics.ClassSchedules;

public class ClassScheduleController(IClassScheduleService service) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PaginationResponse<ClassScheduleResponseModel>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> List([FromQuery] PaginationRequest request)
    {
        var result = await service.ListAsync(request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(ApiRequest<CreateClassScheduleRequestModel> request)
    {
        var result = await service.CreateAsync(request.Request);
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