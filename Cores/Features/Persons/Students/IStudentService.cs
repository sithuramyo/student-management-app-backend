using Cores.Features.Services;
using Shares.Models.Persons.Students;

namespace Cores.Features.Persons.Students;

public interface
    IStudentService : IServiceWrapper<StudentResponseModel, CreateStudentRequestModel, UpdateStudentRequestModel>
{
    Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, StudentStatus studentStatus);
}