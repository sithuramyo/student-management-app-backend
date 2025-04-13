using Cores.Features.Services;
using Shares.Models.Academics.AcademicTerms;

namespace Cores.Features.Academics.AcademicTerms;

public interface IAcademicTermService : IServiceWrapper<AcademicTermResponseModel, CreateAcademicTermRequestModel, UpdateAcademicTermRequestModel>
{

}