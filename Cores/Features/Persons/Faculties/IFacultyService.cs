using Cores.Features.Services;
using Shares.Models.Persons.Faculties;

namespace Cores.Features.Persons.Faculties;

public interface
    IFacultyService : IServiceWrapper<FacultyResponseModel, CreateFacultyRequestModel, UpdateFacultyRequestModel>
{
    Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, FacultyStatus facultyStatus);
}