using Infrastructures.DataModels.Academics;
using Shares.Models.Academics.CourseOfferings;

namespace Cores.Features.Academics.CourseOfferings;

public class CourseOfferingService(AppDbContext context) : ICourseOfferingService
{
    public async Task<ApiResponse<PaginationResponse<CourseOfferingResponseModel>>> ListAsync(PaginationRequest request)
    {
        var offeringsQuery = context.CourseOfferings
            .Where(x => !x.IsDeleted)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var termIds = await context.AcademicTerms
                .Where(t => EF.Functions.ILike(t.Name, $"%{request.Search}%"))
                .Select(t => t.Id)
                .ToListAsync();

            var courseIds = await context.Courses
                .Where(c => EF.Functions.ILike(c.Title, $"%{request.Search}%"))
                .Select(c => c.Id)
                .ToListAsync();

            offeringsQuery = offeringsQuery.Where(x =>
                termIds.Contains(x.AcademicTermId) || courseIds.Contains(x.CourseId));
        }

        var terms = await context.AcademicTerms.AsNoTracking().ToDictionaryAsync(x => x.Id);
        var courses = await context.Courses.AsNoTracking().ToDictionaryAsync(x => x.Id);
        var faculties = await context.Faculties.AsNoTracking().ToDictionaryAsync(x => x.SystemUserId);

        var flatData = await offeringsQuery
            .Select(x => new
            {
                x.AcademicTermId,
                x.CourseId,
                x.FacultyId
            })
            .ToListAsync();

        var groupedData = flatData
            .GroupBy(x => x.AcademicTermId)
            .Select(g => new CourseOfferingResponseModel
            {
                AcademicTermId = g.Key,
                AcademicTerm = terms.TryGetValue(g.Key, out var term) ? term.Name : "N/A",
                CourseFacultyInfos = g.Select(x => new CourseFacultyInfoResponseModel
                {
                    CourseId = x.CourseId,
                    CourseName = courses.TryGetValue(x.CourseId, out var course) ? course.Title : "N/A",
                    FacultyId = x.FacultyId,
                    FacultyName = faculties.TryGetValue(x.FacultyId, out var faculty) ? faculty.Name : "N/A"
                }).ToList()
            })
            .ToList();

        var totalCount = groupedData.Count;
        var pagedItems = groupedData
            .Skip(request.Skip)
            .Take(request.PageSize)
            .ToList();

        var result = new PaginationResponse<CourseOfferingResponseModel>
        {
            Items = pagedItems,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
        return ApiResponse<PaginationResponse<CourseOfferingResponseModel>>.Success(result);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateCourseOfferingRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.CourseOfferings.AnyAsync(x => x.AcademicTermId == request.AcademicTermId
                                                                  && !x.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Course offering is already exists");
        }

        await context.CourseOfferings.AddRangeAsync(
            request.CourseFacultyInfo.Select(cf => new CourseOffering
            {
                AcademicTermId = request.AcademicTermId,
                CourseId = cf.CourseId,
                FacultyId = cf.FacultyId
            }));
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<CourseOfferingResponseModel>> GetByIdAsync(string id)
    {
        var isExist = await context.CourseOfferings.AnyAsync(x => x.AcademicTermId == id && !x.IsDeleted);
        if (!isExist)
        {
            return ApiResponse<CourseOfferingResponseModel>.NotFound("Course offering not found");
        }

        var offerings = await context.CourseOfferings
            .Where(x => x.AcademicTermId == id && !x.IsDeleted)
            .AsNoTracking()
            .ToListAsync();

        var response = new CourseOfferingResponseModel
        {
            AcademicTermId = id,
            CourseFacultyInfos = offerings.Select(x => new CourseFacultyInfoResponseModel
            {
                CourseId = x.CourseId,
                FacultyId = x.FacultyId,
            }).ToList()
        };
        return ApiResponse<CourseOfferingResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateCourseOfferingRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.CourseOfferings.AnyAsync(x => x.AcademicTermId != request.AcademicTermId
                                                                  && !x.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Course offering is already exists");
        }

        var oldOfferings = await context.CourseOfferings
            .Where(x => x.AcademicTermId == request.AcademicTermId)
            .ToListAsync();
        context.CourseOfferings.RemoveRange(oldOfferings);

        var newOfferings = request.CourseFacultyInfo.Select(cf => new CourseOffering
        {
            AcademicTermId = request.AcademicTermId,
            CourseId = cf.CourseId,
            FacultyId = cf.FacultyId
        });

        await context.CourseOfferings.AddRangeAsync(newOfferings);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.CourseOfferings.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Course Offering not found");
        }

        data.IsDeleted = true;
        context.CourseOfferings.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}