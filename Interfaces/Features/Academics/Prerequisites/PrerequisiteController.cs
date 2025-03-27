using Cores.Features.Academics.Prerequisites;
using Shares.Models.Academics.Prerequisites;

namespace Interfaces.Features.Academics.Prerequisites;

[Authorize]
public class PrerequisiteController(IPrerequisiteService service) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PaginationResponse<PrerequisiteResponseModel>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> List([FromQuery] PaginationRequest request)
    {
        var result = await service.ListAsync(request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(ApiRequest<CreatePrerequisiteRequestModel> request)
    {
        var result = await service.CreateAsync(request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<PrerequisiteResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetById(string id)
    {
        var result = await service.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(string id, ApiRequest<UpdatePrerequisiteRequestModel> request)
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