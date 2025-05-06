using Infrastructures.DataModels.Academics;
using Shares.Models.Academics.ClassSchedules;

namespace Cores.Features.Academics.ClassSchedules;

public class ClassScheduleService(AppDbContext context) : IClassScheduleService
{
    public async Task<ApiResponse<PaginationResponse<ClassScheduleResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.ClassSchedules.Where(d => !d.IsDeleted).AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                EF.Functions.ILike(d.CourseTitle, $"%{request.Search}%") ||
                EF.Functions.ILike(d.FacultyName, $"%{request.Search}%"));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new ClassScheduleResponseModel
        {
            Id = d.Id,
            CourseTitle = d.CourseTitle,
            FacultyName = d.FacultyName,
            ScheduleDate = d.ScheduleDate,
            DayOfWeek = d.DayOfWeek,
            StartTime = d.StartTime,
            EndTime = d.EndTime,
            Location = d.Location
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<ClassScheduleResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateClassScheduleRequestModel request)
    {
        NoResponseModel response = new();
        var courseOfferingIds = request.CourseSchedules.Select(c => c.CourseOfferingId).ToList();
        var isExist = await context.ClassSchedules.AnyAsync(x => courseOfferingIds.Contains(x.CourseOfferingId) && !x.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Course Schedule already exists");
        }

        await context.ClassSchedules.AddRangeAsync(
                    request.CourseSchedules.Select(cs => new ClassSchedule
                    {
                        CourseOfferingId = cs.CourseOfferingId,
                        CourseTitle = cs.CourseTitle,
                        FacultyName = cs.FacultyName,
                        ScheduleDate = cs.ScheduleDate,
                        DayOfWeek = cs.DayOfWeek,
                        StartTime = cs.StartTime,
                        EndTime = cs.EndTime,
                        Location = cs.Location
                    }));
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<ClassScheduleResponseModel>> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateClassScheduleRequestModel request)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.ClassSchedules.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Course Offering not found");
        }

        data.IsDeleted = true;
        context.ClassSchedules.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}