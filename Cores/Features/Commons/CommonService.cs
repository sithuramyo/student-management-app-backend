using System.Linq.Dynamic.Core;
using Shares.Models.Commons;

namespace Cores.Features.Commons;

public class CommonService(AppDbContext context) : ICommonService
{
    public async Task<ApiResponse<DepartmentsResponseModel>> GetDepartmentsAsync()
    {
        DepartmentsResponseModel response = new();
        var departments = await context.Departments
            .Where(d => !d.IsDeleted)
            .Select(d => new Departments
            {
                Id = d.Id,
                Code = d.Code,
                Name = d.Name,
                Description = d.Description ?? "N/A",
            }).ToListAsync();
        response.Departments = departments;
        return ApiResponse<DepartmentsResponseModel>.Success(response);
    }

    public async Task<ApiResponse<CoursesResponseModel>> GetCoursesAsync()
    {
        CoursesResponseModel response = new();
        var courses = await context.Courses
            .Where(c => !c.IsDeleted)
            .Select(c => new Courses
            {
                Id = c.Id,
                Code = c.Code,
                Title = c.Title,
                Profile = c.Profile,
            }).ToListAsync();
        return ApiResponse<CoursesResponseModel>.Success(response);
    }
}