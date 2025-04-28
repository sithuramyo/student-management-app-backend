using Cores.Features.Services;
using Shares.Models.Academics.ClassSchedules;

namespace Cores.Features.Academics.ClassSchedules;

public interface IClassScheduleService : IServiceWrapper<ClassScheduleResponseModel, CreateClassScheduleRequestModel, UpdateClassScheduleRequestModel>
{

}