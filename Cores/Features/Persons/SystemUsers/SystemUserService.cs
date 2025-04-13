using Infrastructures.DataModels.SystemUsers;
using Shares.Models.Persons.SystemUsers;

namespace Cores.Features.Persons.SystemUsers;

public class SystemUserService(AppDbContext context) : ISystemUserService
{
    public async Task<ApiResponse<PaginationResponse<SystemUserResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.SystemUsers.Where(c =>
                !c.IsDeleted && c.Role != SystemUserRole.Faculty.ToString() &&
                c.Role != SystemUserRole.Student.ToString() && !c.IsDeleted)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                EF.Functions.ILike(d.Name, $"%{request.Search}%") ||
                EF.Functions.ILike(d.Role, $"%{request.Search}%"));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new SystemUserResponseModel
        {
            Id = d.Id,
            Name = d.Name,
            Profile = d.Profile ?? "N/A",
            Role = d.Role,
            Email = d.Email,
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<SystemUserResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateSystemUserRequestModel request)
    {
        NoResponseModel response = new();

        var isSuperAdmin = request.Role == SystemUserRole.SuperAdmin;
        if (isSuperAdmin)
        {
            return ApiResponse<NoResponseModel>.BadRequest("Can't create super admin system user");
        }

        var isExist = await context.SystemUsers.AnyAsync(x =>
            x.Email == request.Email && x.Name == request.Name && x.Role == request.Role.ToString() &&
            !x.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("System User already exists");
        }

        SystemUser systemUser = new()
        {
            Name = request.Name,
            Email = request.Email,
            Password = PasswordHelper.HashPassword(request.Password),
            Role = request.Role.ToString(),
            Profile = request.Profile
        };
        await context.SystemUsers.AddAsync(systemUser);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<SystemUserResponseModel>> GetByIdAsync(string id)
    {
        SystemUserResponseModel response = new();
        var data = await context.SystemUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<SystemUserResponseModel>.NotFound("System User not found");
        }

        response.Id = data.Id;
        response.Name = data.Name;
        response.Profile = data.Profile ?? "N/A";
        response.Email = data.Email;
        response.Role = data.Role;
        return ApiResponse<SystemUserResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateSystemUserRequestModel request)
    {
        NoResponseModel response = new();

        var isSuperAdmin = request.Role == SystemUserRole.SuperAdmin;
        if (isSuperAdmin)
        {
            return ApiResponse<NoResponseModel>.BadRequest("Can't update super admin system user");
        }

        var exist = await context.SystemUsers.AnyAsync(x =>
            x.Email == request.Email && x.Name == request.Name && x.Role == request.Role.ToString() &&
            !x.IsDeleted && x.Id != id);

        if (exist)
        {
            return ApiResponse<NoResponseModel>.Conflict("System User already exists");
        }
        
        var data = context.SystemUsers.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("System User not found");
        }

        data.Name = request.Name;
        data.Email = request.Email;
        data.Password = PasswordHelper.HashPassword(request.Password);
        data.Role = request.Role.ToString();
        data.Profile = request.Profile;
        context.SystemUsers.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.SystemUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("System User not found");
        }

        data.IsDeleted = true;
        context.SystemUsers.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}