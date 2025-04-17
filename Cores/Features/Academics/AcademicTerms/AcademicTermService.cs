using Infrastructures.DataModels.Academics;
using Shares.Models.Academics.AcademicTerms;

namespace Cores.Features.Academics.AcademicTerms;

public class AcademicTermService(AppDbContext context) : IAcademicTermService
{
    public async Task<ApiResponse<PaginationResponse<AcademicTermResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.AcademicTerms.Where(c =>
                !c.IsDeleted)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.ToLower();
            query = query.Where(d =>
                EF.Functions.ILike(d.Name, $"%{search}%"));

            query = query.AsEnumerable().Where(d =>
                    d.StartDate.ToString("yyyy-MM-dd").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    d.EndDate.ToString("yyyy-MM-dd").Contains(search, StringComparison.OrdinalIgnoreCase))
                .AsQueryable();
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new AcademicTermResponseModel
        {
            Id = d.Id,
            Name = d.Name,
            Profile = d.Profile ?? "N/A",
            StartDate = d.StartDate,
            EndDate = d.EndDate,
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<AcademicTermResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateAcademicTermRequestModel request)
    {
        NoResponseModel response = new();

        var exists = await context.AcademicTerms.AnyAsync(x =>
            x.Name == request.Name && !x.IsDeleted);

        if (exists)
        {
            return ApiResponse<NoResponseModel>.Conflict("An academic term with the same name already exists");
        }

        AcademicTerm academicTerm = new()
        {
            Name = request.Name,
            Profile = request.Profile ?? "N/A",
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };
        await context.AcademicTerms.AddAsync(academicTerm);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<AcademicTermResponseModel>> GetByIdAsync(string id)
    {
        AcademicTermResponseModel response = new();
        var data = await context.AcademicTerms.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<AcademicTermResponseModel>.NotFound("Academic term not found");
        }

        response.Id = data.Id;
        response.Name = data.Name;
        response.Profile = data.Profile ?? "N/A";
        response.StartDate = data.StartDate;
        response.EndDate = data.EndDate;
        return ApiResponse<AcademicTermResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateAcademicTermRequestModel request)
    {
        NoResponseModel response = new();

        var exists = await context.AcademicTerms.AnyAsync(x =>
            x.Name == request.Name && !x.IsDeleted && x.Id == id);

        if (exists)
        {
            return ApiResponse<NoResponseModel>.Conflict("An academic term with the same name already exists");
        }

        var data = context.AcademicTerms.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Academic term not found");
        }

        data.Name = request.Name;
        data.Profile = request.Profile;
        data.StartDate = request.StartDate;
        data.EndDate = request.EndDate;
        context.AcademicTerms.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.AcademicTerms.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Academic term not found");
        }

        data.IsDeleted = true;
        context.AcademicTerms.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}