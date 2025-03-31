using Shares.Models.Commons;

namespace Cores.Features.Commons;

public interface ICommonService
{
    Task<ApiResponse<DepartmentsResponseModel>> GetDepartmentsAsync();
    Task<ApiResponse<CoursesResponseModel>> GetCoursesAsync();
    Task<ApiResponse<PrerequisiteResponseModel>> GetPrerequisitesAsync();
}