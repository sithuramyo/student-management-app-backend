using Cores.Features.Services;
using Shares.Models.Academics.Courses;

namespace Cores.Features.Academics.Courses;

public interface ICourseService : IServiceWrapper<CourseResponseModel, CreateCourseRequestModel, UpdateCourseRequestModel>
{

}