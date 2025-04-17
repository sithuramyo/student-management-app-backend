using Shares.Models.Commons;

namespace Cores.Features.Commons;

public interface ICommonService
{
    Task<ApiResponse<DepartmentsResponseModel>> GetDepartmentsAsync();
    Task<ApiResponse<CoursesResponseModel>> GetCoursesAsync();
    Task<ApiResponse<PrerequisitesResponseModel>> GetPrerequisitesAsync();
    Task<ApiResponse<FacultiesResponseModel>> GetFacultiesAsync();
    Task<ApiResponse<AcademicTermsResponseModel>> GetAcademicTermsAsync();

}