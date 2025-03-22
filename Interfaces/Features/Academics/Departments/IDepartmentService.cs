using Shares.Models.Academics.Departments;
using Shares.Models.Paginations;

namespace Interfaces.Features.Academics.Departments;

public interface IDepartmentService
{
    Task<ApiResponse<PaginationResponse<DepartmentResponseModel>>> DepartmentListAsync(PaginationRequest request);
}