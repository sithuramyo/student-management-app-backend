using Shares.Models.Academics.Departments;

namespace Interfaces.Features.Academics.Departments;

public class DepartmentService(AppDbContext context) : IDepartmentService
{
    public async Task<ApiResponse<PaginationResponse<DepartmentResponseModel>>> DepartmentListAsync(
        PaginationRequest request)
    {
        PaginationResponse<DepartmentResponseModel> response = new();
        var query = context.Departments.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                EF.Functions.ILike(d.Name, $"%{request.Search}%") ||
                EF.Functions.ILike(d.Code, $"%{request.Search}%"));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new DepartmentResponseModel
        {
            Id = d.Id,
            Code = d.Code,
            Name = d.Name,
            Description = d.Description,
            PhoneNumber = d.PhoneNumber,
            Email = d.Email,
            OfficeLocation = d.OfficeLocation
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<DepartmentResponseModel>>.Success(paginated);
    }
}