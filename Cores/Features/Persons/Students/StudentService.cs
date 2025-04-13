using Infrastructures.DataModels.Persons;
using Infrastructures.DataModels.SystemUsers;
using Shares.Models.Persons.Students;

namespace Cores.Features.Persons.Students;

public class StudentService(AppDbContext context) : IStudentService
{
    public async Task<ApiResponse<PaginationResponse<StudentResponseModel>>> ListAsync(PaginationRequest request)
    {
        var query = context.Students.Where(c => !c.IsDeleted).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(d =>
                EF.Functions.ILike(d.Name, $"%{request.Search}%") ||
                EF.Functions.ILike(d.Code, $"%{request.Search}%"));
        }

        query = query.ApplySorting(request.SortBy, request.IsAscending);

        var projectedQuery = query.Select(d => new StudentResponseModel
        {
            Id = d.Id,
            Code = d.Code,
            Name = d.Name,
            Profile = d.Profile ?? "N/A",
            BirthDate = d.BirthDate,
            Gender = d.Gender,
            Status = d.Status
        });

        var paginated = await projectedQuery.ToPagedListAsync(request);
        return ApiResponse<PaginationResponse<StudentResponseModel>>.Success(paginated);
    }

    public async Task<ApiResponse<NoResponseModel>> CreateAsync(CreateStudentRequestModel request)
    {
        NoResponseModel response = new();
        var isExist = await context.Students.AnyAsync(x =>
            x.PhoneNumber == request.StudentInfo.PhoneNumber && x.Name == request.StudentInfo.Name &&
            x.Gender == request.StudentInfo.Gender.ToString() && !x.IsDeleted);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Student already exists");
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        SystemUser systemUser = new()
        {
            Name = request.StudentInfo.Name,
            Email = request.LoginInfo.Email,
            Password = PasswordHelper.HashPassword(request.LoginInfo.Password),
            Role = SystemUserRole.Student.ToString(),
            Profile = request.StudentInfo.Profile
        };
        await context.SystemUsers.AddAsync(systemUser);
        await context.SaveChangesAsync();
        var studentCount = await context.Students.CountAsync();
        Student students = new()
        {
            SystemUserId = systemUser.Id,
            Name = request.StudentInfo.Name,
            Code = Codes.StudentCode.GetCode(studentCount, Codes.StudentDigit),
            BirthDate = request.StudentInfo.BirthDate,
            Gender = request.StudentInfo.Gender.ToString(),
            PhoneNumber = request.StudentInfo.PhoneNumber,
            Address = request.StudentInfo.Address,
            Status = request.StudentInfo.Status.ToString(),
            Profile = request.StudentInfo.Profile,
        };
        await context.Students.AddAsync(students);
        await context.SaveChangesAsync();
        Guardian guardian = new()
        {
            StudentId = students.Id,
            Name = request.GuardianInfo.Name,
            Relationship = request.GuardianInfo.Relationship,
            ContactNumber = request.GuardianInfo.ContactNumber,
            Email = request.GuardianInfo.Email,
            Address = request.GuardianInfo.Address,
        };
        await context.Guardians.AddAsync(guardian);
        await context.SaveChangesAsync();
        await transaction.CommitAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<StudentResponseModel>> GetByIdAsync(string id)
    {
        StudentResponseModel response = new();
        var data = await context.Students.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<StudentResponseModel>.NotFound("Student not found");
        }

        response.Id = data.Id;
        response.Name = data.Name;
        response.Profile = data.Profile ?? "N/A";
        response.BirthDate = data.BirthDate;
        response.Gender = ((int)Enum.Parse<Gender>(data.Gender)).ToString();
        response.Status = ((int)Enum.Parse<StudentStatus>(data.Status)).ToString();
        return ApiResponse<StudentResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, UpdateStudentRequestModel request)
    {
        NoResponseModel response = new();
        var data = await context.Students.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Student not found");
        }

        var isExist = await context.Students.AnyAsync(x =>
            x.PhoneNumber == request.PhoneNumber && x.Name == request.Name &&
            x.Gender == request.Gender.ToString() && !x.IsDeleted && x.Id != id);

        if (isExist)
        {
            return ApiResponse<NoResponseModel>.Conflict("Student already exists");
        }

        data.Name = request.Name;
        data.Profile = request.Profile;
        data.BirthDate = request.BirthDate;
        data.Gender = request.Gender.ToString();
        data.Status = request.Status.ToString();
        data.PhoneNumber = request.PhoneNumber;
        data.Address = request.Address;
        context.Students.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, StudentStatus studentStatus)
    {
        NoResponseModel response = new();
        var data = await context.Students.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Student not found");
        }

        data.Status = studentStatus.ToString();
        context.Students.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }

    public async Task<ApiResponse<NoResponseModel>> DeleteAsync(string id)
    {
        NoResponseModel response = new();
        var data = await context.Students.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (data is null)
        {
            return ApiResponse<NoResponseModel>.NotFound("Student not found");
        }

        data.IsDeleted = true;
        context.Students.Update(data);
        await context.SaveChangesAsync();
        return ApiResponse<NoResponseModel>.Success(response);
    }
}