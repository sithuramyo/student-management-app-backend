using Shares.Models.Faculties;

namespace Cores.Features.Faculites;

public class UserFacultyService(AppDbContext context) : IUserFacultyService
{
    public async Task<ApiResponse<FacultyClassScheduleResponseModel>> GetFacultyClassSchedule(string facultyId)
    {
        FacultyClassScheduleResponseModel response = new();
        var data = await (from cs in context.ClassSchedules
                          join co in context.CourseOfferings on cs.CourseOfferingId equals co.Id
                          join c in context.Courses on co.CourseId equals c.Id
                          join f in context.Faculties on co.FacultyId equals f.SystemUserId
                          join at in context.AcademicTerms on co.AcademicTermId equals at.Id
                          where f.SystemUserId == facultyId
                          select new FacultyClassSchedule
                          {
                              Id = cs.Id,
                              Term = at.Name,
                              CourseTitle = c.Title,
                              StartTime = cs.StartTime,
                              EndTime = cs.EndTime,
                              ScheduleDate = cs.ScheduleDate
                          }).ToListAsync();
        response.FacultyClassSchedules = data;
        return ApiResponse<FacultyClassScheduleResponseModel>.Success(response);
    }
}