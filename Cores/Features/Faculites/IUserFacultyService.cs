using Shares.Models.Faculties;

namespace Cores.Features.Faculites;

public interface IUserFacultyService
{
    Task<ApiResponse<FacultyClassScheduleResponseModel>> GetFacultyClassSchedule(string facultyId);

    Task<ApiResponse<FacultyTodayClassScheduleResponseModel>> GetFacultyTodayClassSchedule(
        string facultyId);
}