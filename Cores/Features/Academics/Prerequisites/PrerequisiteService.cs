using Infrastructures.DataModels.Academics;
using Shares.Models.Academics.Prerequisites;

namespace Cores.Features.Academics.Prerequisites;

public class PrerequisiteService(AppDbContext context) : IPrerequisiteService
{
    public async Task<ApiResponse<PaginationResponse<PrerequisiteResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.Prerequisites.Where(d => !d.IsDeleted).AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                d.RequiredMinimumGrade != null && (EF.Functions.ILike(d.RequiredCourseCode, $"%{request.Search}%") ||
                                                   EF.Functions.ILike(d.RequiredMinimumGrade, $"%{request.Search}%")));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new PrerequisiteResponseModel
        {
            Id = d.Id,
            RequiredCourseCode = d.RequiredCourseCode,
            RequiredMinimumGrade = d.RequiredMinimumGrade ?? "N/A",
            IsMandatory = d.IsMandatory,
            Notes = d.Notes ?? "N/A",
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<PrerequisiteResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreatePrerequisiteRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.Prerequisites.AnyAsync(d => d.RequiredCourseCode == request.RequiredCourseCode
                                                                && d.RequiredMinimumGrade ==
                                                                request.RequiredMinimumGrade && !d.IsDeleted);
        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Prerequisite already exists");
        }

        Prerequisite data = new()
        {
            RequiredCourseCode = request.RequiredCourseCode,
            RequiredMinimumGrade = request.RequiredMinimumGrade,
            IsMandatory = request.IsMandatory,
            Notes = request.Notes,
        };
        await context.Prerequisites.AddAsync(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<PrerequisiteResponseModel>> GetByIdAsync(string id)
    {
        var data = await context.Prerequisites.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<PrerequisiteResponseModel>.NotFound("Prerequisite not found");
        }

        PrerequisiteResponseModel response = new()
        {
            Id = data.Id,
            RequiredCourseCode = data.RequiredCourseCode,
            RequiredMinimumGrade = data.RequiredMinimumGrade,
            IsMandatory = data.IsMandatory,
            Notes = data.Notes,
        };
        return ApiResponse<PrerequisiteResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdatePrerequisiteRequestModel request)
    {
        NoResponseModel response = new();

        var data = await context.Prerequisites.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Prerequisite not found");
        }


        var isExist = await context.Prerequisites.AnyAsync(d => d.RequiredCourseCode == request.RequiredCourseCode
                                                                && d.RequiredMinimumGrade ==
                                                                request.RequiredMinimumGrade && d.Id != id &&
                                                                !d.IsDeleted);
        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Prerequisite already exists");
        }

        data.RequiredCourseCode = request.RequiredCourseCode;
        data.RequiredMinimumGrade = request.RequiredMinimumGrade;
        data.IsMandatory = request.IsMandatory;
        data.Notes = request.Notes;
        context.Prerequisites.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.Prerequisites.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Prerequisite not found");
        }

        data.IsDeleted = true;
        context.Prerequisites.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}