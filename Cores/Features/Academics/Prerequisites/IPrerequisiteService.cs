using Cores.Features.Services;
using Shares.Models.Academics.Prerequisites;

namespace Cores.Features.Academics.Prerequisites;

public interface IPrerequisiteService : IServiceWrapper<PrerequisiteResponseModel, CreatePrerequisiteRequestModel, UpdatePrerequisiteRequestModel>
{

}