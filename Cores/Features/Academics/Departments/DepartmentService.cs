using Infrastructures.Databases;
using Infrastructures.DataModels.Academics;
using Microsoft.EntityFrameworkCore;
using Shares.Constants;
using Shares.Extensions;
using Shares.Models.Academics.Departments;
using Shares.Models.ApiModels;
using Shares.Models.Paginations;

namespace Cores.Features.Academics.Departments;

public class DepartmentService(AppDbContext context) : IDepartmentService
{
    public async Task<ApiResponse<PaginationResponse<DepartmentResponseModel>>> ListAsync(
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

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateDepartmentRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.Departments.AnyAsync(d => d.Name == request.Name && !d.IsDeleted);
        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Department already exists");
        }

        var countAsync = await context.Departments.CountAsync();
        Department data = new()
        {
            Code = Codes.DepartmentCode.GetCode(countAsync, Codes.DepartmentDigit),
            Name = request.Name,
            Description = request.Description,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            OfficeLocation = request.OfficeLocation,
        };
        await context.Departments.AddAsync(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<DepartmentResponseModel>> GetByIdAsync(string id)
    {
        var data = await context.Departments.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<DepartmentResponseModel>.NotFound("Department not found");
        }

        DepartmentResponseModel response = new()
        {
            Id = data.Id,
            Code = data.Code,
            Name = data.Name,
            Description = data.Description,
            PhoneNumber = data.PhoneNumber,
            Email = data.Email,
            OfficeLocation = data.OfficeLocation,
        };
        return ApiResponse<DepartmentResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateDepartmentRequestModel request)
    {
        NoResponseModel response = new();
        var data = await context.Departments.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Department not found");
        }

        data.Id = id;
        data.Name = request.Name;
        data.Description = request.Description;
        data.PhoneNumber = request.PhoneNumber;
        data.Email = request.Email;
        data.OfficeLocation = request.OfficeLocation;
        context.Departments.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.Departments.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Department not found");
        }

        data.IsDeleted = true;
        context.Departments.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}