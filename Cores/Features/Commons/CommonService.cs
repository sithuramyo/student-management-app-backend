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
        response.Courses = courses;
        return ApiResponse<CoursesResponseModel>.Success(response);
    }

    public async Task<ApiResponse<PrerequisitesResponseModel>> GetPrerequisitesAsync()
    {
        PrerequisitesResponseModel response = new();
        var prerequisites = await context.Prerequisites
            .Where(p => !p.IsDeleted)
            .Select(p => new Prerequisites
            {
                Id = p.Id,
                RequiredCourseCode = p.RequiredCourseCode,
                RequiredMinimumGrade = p.RequiredMinimumGrade ?? "N/A",
                IsMandatory = p.IsMandatory,
                Notes = p.Notes ?? "N/A",
            }).ToListAsync();
        response.Prerequisites = prerequisites;
        return ApiResponse<PrerequisitesResponseModel>.Success(response);
    }

    public async Task<ApiResponse<FacultiesResponseModel>> GetFacultiesAsync()
    {
        FacultiesResponseModel response = new();
        var faculties = await context.Faculties
            .Where(f => !f.IsDeleted)
            .Select(f => new Faculty
            {
                Id = f.Id,
                Name = f.Name
            }).ToListAsync();
        response.Faculties = faculties;
        return ApiResponse<FacultiesResponseModel>.Success(response);
    }

    public async Task<ApiResponse<AcademicTermsResponseModel>> GetAcademicTermsAsync()
    {
        AcademicTermsResponseModel response = new();
        var today = DateOnly.FromDateTime(DateTime.Now);
        var academicTerms = await context.AcademicTerms
            .Where(a => !a.IsDeleted && a.EndDate > today)
            .Select(a => new AcademicTerm
            {
                Id = a.Id,
                Name = a.Name,
                StartDate = a.StartDate,
                EndDate = a.EndDate
            }).ToListAsync();
        response.AcademicTerms = academicTerms;
        return ApiResponse<AcademicTermsResponseModel>.Success(response);
    }
}