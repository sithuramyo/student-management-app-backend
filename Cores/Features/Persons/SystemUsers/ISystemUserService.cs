using Cores.Features.Services;
using Shares.Models.Persons.SystemUsers;

namespace Cores.Features.Persons.SystemUsers;

public interface ISystemUserService : IServiceWrapper<SystemUserResponseModel,CreateSystemUserRequestModel,UpdateSystemUserRequestModel>
{
    
}