using Shares.Models.Commons;
using Shares.Models.Communications;

namespace Cores.Features.Commons;

public interface ICommonService
{
    Task<ApiResponse<DepartmentsResponseModel>> GetDepartmentsAsync();
    Task<ApiResponse<CoursesResponseModel>> GetCoursesAsync();
    Task<ApiResponse<PrerequisitesResponseModel>> GetPrerequisitesAsync();
    Task<ApiResponse<FacultiesResponseModel>> GetFacultiesAsync();
    Task<ApiResponse<AcademicTermsResponseModel>> GetAcademicTermsAsync();
    Task<ApiResponse<CourseOfferingsResponseModel>> GetCourseOfferingAsync(string academicTermId);
    Task<ApiResponse<List<UsersResponseModel>>> GetUsersAsync(string search);

}