using Infrastructures.DataModels.Persons;
using Infrastructures.DataModels.SystemUsers;
using Shares.Models.Persons.Faculties;

namespace Cores.Features.Persons.Faculties;

public class FacultyService(AppDbContext context) : IFacultyService
{
    public async Task<ApiResponse<PaginationResponse<FacultyResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.Faculties.Where(c => !c.IsDeleted).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                EF.Functions.ILike(d.Name, $"%{request.Search}%") ||
                EF.Functions.ILike(d.Code, $"%{request.Search}%"));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new FacultyResponseModel
        {
            Id = d.Id,
            Code = d.Code,
            Name = d.Name,
            Profile = d.Profile ?? "N/A",
            BirthDate = d.BirthDate,
            Gender = d.Gender,
            Status = d.Status,
            PhoneNumber = d.PhoneNumber,
            Specialization = d.Specialization
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<FacultyResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateFacultyRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.Faculties.AnyAsync(x =>
            x.PhoneNumber == request.FacultyInfo.PhoneNumber && x.Name == request.FacultyInfo.Name &&
            x.Gender == request.FacultyInfo.Gender.ToString() && !x.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Faculty already exists");
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        SystemUser systemUser = new()
        {
            Name = request.FacultyInfo.Name,
            Email = request.LoginInfo.Email,
            Password = PasswordHelper.HashPassword(request.LoginInfo.Password),
            Role = SystemUserRole.Faculty.ToString(),
            Profile = request.FacultyInfo.Profile
        };
        await context.SystemUsers.AddAsync(systemUser);
        await context.SaveChangesAsync();
        var facultyCount = await context.Faculties.CountAsync();
        Faculty faculties = new()
        {
            SystemUserId = systemUser.Id,
            Name = request.FacultyInfo.Name,
            Code = Codes.FacultyCode.GetCode(facultyCount, Codes.FacultyDigit),
            BirthDate = request.FacultyInfo.BirthDate,
            Gender = request.FacultyInfo.Gender.ToString(),
            PhoneNumber = request.FacultyInfo.PhoneNumber,
            Status = request.FacultyInfo.Status.ToString(),
            Profile = request.FacultyInfo.Profile,
            Specialization = request.FacultyInfo.Specialization,
        };
        await context.Faculties.AddAsync(faculties);
        await context.SaveChangesAsync();
        await transaction.CommitAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<FacultyResponseModel>> GetByIdAsync(string id)
    {
        FacultyResponseModel response = new();
        var data = await context.Faculties.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<FacultyResponseModel>.NotFound("Faculty not found");
        }

        response.Id = data.Id;
        response.Name = data.Name;
        response.Profile = data.Profile ?? "N/A";
        response.BirthDate = data.BirthDate;
        response.Gender = data.Gender;
        response.Status = data.Status;
        response.PhoneNumber = data.PhoneNumber;
        response.Specialization = data.Specialization;
        return ApiResponse<FacultyResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateFacultyRequestModel request)
    {
        NoResponseModel response = new();
        var data = await context.Faculties.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Faculty not found");
        }

        var isExist = await context.Faculties.AnyAsync(x =>
            x.PhoneNumber == request.PhoneNumber && x.Name == request.Name &&
            x.Gender == request.Gender.ToString() && !x.IsDeleted && x.Id != id);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Faculty already exists");
        }

        data.Name = request.Name;
        data.Profile = request.Profile;
        data.BirthDate = request.BirthDate;
        data.Gender = request.Gender.ToString();
        data.Status = request.Status.ToString();
        data.PhoneNumber = request.PhoneNumber;
        data.Specialization = request.Specialization;
        context.Faculties.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.Faculties.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Faculty not found");
        }

        data.IsDeleted = true;
        context.Faculties.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, FacultyStatus facultyStatus)
    {
        NoResponseModel response = new();
        var data = await context.Faculties.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Faculty not found");
        }
        data.Status = facultyStatus.ToString();
        context.Faculties.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}