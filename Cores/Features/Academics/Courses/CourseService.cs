using Infrastructures.DataModels.Academics;
using Infrastructures.DataModels.ManyToMany;
using Shares.Models.Academics.Courses;

namespace Cores.Features.Academics.Courses;

public class CourseService(AppDbContext context) : ICourseService
{
    public async Task<ApiResponse<PaginationResponse<CourseResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.Courses.Where(c => !c.IsDeleted).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                EF.Functions.ILike(d.Title, $"%{request.Search}%") ||
                EF.Functions.ILike(d.Code, $"%{request.Search}%"));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = from course in query
                             join dept in context.Departments.AsNoTracking()
                                 on course.DepartmentId equals dept.Id
                             select new CourseResponseModel
                             {
                                 Id = course.Id,
                                 DepartmentName = dept.Name,
                                 Profile = course.Profile,
                                 Code = course.Code,
                                 Title = course.Title,
                                 Description = course.Description,
                                 CreditHours = course.CreditHours,
                                 SemesterOffered = course.SemesterOffered,
                                 MaxEnrollment = course.MaxEnrollment,
                                 SyllabusUrl = course.SyllabusUrl,
                                 DeliveryMode = course.DeliveryMode
                             };

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<CourseResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateCourseRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.Courses.AnyAsync(c =>
            c.Code == request.Code && c.Title == request.Title && c.CreditHours == request.CreditHours && !c.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Course already exists");
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        Course data = new()
        {
            Profile = request.Profile,
            DepartmentId = request.DepartmentId,
            Code = request.Code,
            Title = request.Title,
            Description = request.Description,
            CreditHours = request.CreditHours,
            SemesterOffered = request.SemesterOffered,
            MaxEnrollment = request.MaxEnrollment,
            SyllabusUrl = request.SyllabusUrl,
            DeliveryMode = request.DeliveryMode,
        };
        await context.Courses.AddAsync(data);

        if (request.PrerequisiteIds is { Length: > 0 })
        {
            List<CoursePrerequisite> prerequisites = [];
            prerequisites.AddRange(request.PrerequisiteIds.Select(prerequisiteId => new CoursePrerequisite
            { CourseId = data.Id, PrerequisiteId = prerequisiteId }));
            await context.CoursePrerequisites.AddRangeAsync(prerequisites);
        }

        await context.SaveChangesAsync();
        await transaction.CommitAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<CourseResponseModel>> GetByIdAsync(string id)
    {
        CourseResponseModel response = new();
        var data = await context.Courses.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        if (data is null)
        {
            return ApiResponse<CourseResponseModel>.NotFound("Course not found");
        }

        var prerequisiteIds = await context.CoursePrerequisites.Where(p => p.CourseId == id && !p.IsDeleted)
            .Select(p => p.PrerequisiteId)
            .ToArrayAsync();

        response.Id = data.Id;
        response.PrerequisiteIds = prerequisiteIds;
        response.DepartmentId = data.DepartmentId;
        response.Code = data.Code;
        response.Profile = data.Profile;
        response.Title = data.Title;
        response.Description = data.Description;
        response.CreditHours = data.CreditHours;
        response.SemesterOffered = data.SemesterOffered;
        response.MaxEnrollment = data.MaxEnrollment;
        response.SyllabusUrl = data.SyllabusUrl;
        response.DeliveryMode = data.DeliveryMode;
        return ApiResponse<CourseResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateCourseRequestModel request)
    {
        NoResponseModel response = new();
        var data = await context.Courses.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Course not found");
        }

        var isExist = await context.Courses.AnyAsync(c =>
            c.Code == request.Code && c.Title == request.Title && c.CreditHours == request.CreditHours &&
            !c.IsDeleted && c.Id != id);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Course already exists");
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        if (request.PrerequisiteIds is { Length: > 0 })
        {
            var oldPrerequisites =
                await context.CoursePrerequisites.Where(p => p.CourseId == id && !p.IsDeleted).ToListAsync();
            if (oldPrerequisites is { Count: > 0 })
            {
                foreach (var oldPrerequisite in oldPrerequisites)
                {
                    oldPrerequisite.IsDeleted = true;
                }

                context.CoursePrerequisites.UpdateRange(oldPrerequisites);
                await context.SaveChangesAsync();
            }

            List<CoursePrerequisite> prerequisites = [];
            prerequisites.AddRange(request.PrerequisiteIds.Select(prerequisiteId => new CoursePrerequisite
            { CourseId = data.Id, PrerequisiteId = prerequisiteId }));
            await context.CoursePrerequisites.AddRangeAsync(prerequisites);
        }

        data.DepartmentId = request.DepartmentId;
        data.Profile = request.Profile;
        data.Code = request.Code;
        data.Title = request.Title;
        data.Description = request.Description;
        data.CreditHours = request.CreditHours;
        data.SemesterOffered = request.SemesterOffered;
        data.MaxEnrollment = request.MaxEnrollment;
        data.SyllabusUrl = request.SyllabusUrl;
        data.DeliveryMode = request.DeliveryMode;
        context.Courses.Update(data);
        await context.SaveChangesAsync();
        await transaction.CommitAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.Courses.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Department not found");
        }

        data.IsDeleted = true;
        context.Courses.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}