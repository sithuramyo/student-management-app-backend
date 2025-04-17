using Cores.Features.Services;
using Shares.Models.Academics.CourseOfferings;

namespace Cores.Features.Academics.CourseOfferings;

public interface ICourseOfferingService : IServiceWrapper<CourseOfferingResponseModel, CreateCourseOfferingRequestModel, UpdateCourseOfferingRequestModel>
{

}