using Cores.Features.Academics.Departments;
using Infrastructures.DataModels.Academics;
using Microsoft.AspNetCore.Authorization;
using Shares.Models.Academics.Departments;

namespace Interfaces.Features.Academics.Departments;

[Authorize]
public class DepartmentController(IDepartmentService service) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PaginationResponse<DepartmentResponseModel>>),StatusCodes.Status200OK)]
    public async Task<ActionResult> List([FromQuery] PaginationRequest request)
    {
        var result = await service.ListAsync(request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>),StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(ApiRequest<CreateDepartmentRequestModel> request)
    {
        var result = await service.CreateAsync(request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<DepartmentResponseModel>),StatusCodes.Status200OK)]
    public async Task<ActionResult> GetById(string id)
    {
        var result = await service.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>),StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(string id, ApiRequest<UpdateDepartmentRequestModel> request)
    {
        var result = await service.UpdateAsync(id, request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse<NoResponseModel>),StatusCodes.Status200OK)]
    public async Task<ActionResult> Delete(string id)
    {
        var result = await service.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
}