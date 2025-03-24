using Shares.Models.Academics.Departments;
using Shares.Models.ApiModels;
using Shares.Models.Paginations;

namespace Cores.Features.Academics.Departments;

public interface IDepartmentService
{
    Task<ApiResponse<PaginationResponse<DepartmentResponseModel>>> ListAsync(PaginationRequest request);
    Task<ApiResponse<NoResponseModel>> CreateAsync(CreateDepartmentRequestModel request);
    Task<ApiResponse<DepartmentResponseModel>> GetByIdAsync(string id);
    Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateDepartmentRequestModel request);
    Task<ApiResponse<NoResponseModel>> DeleteAsync(string id);
}