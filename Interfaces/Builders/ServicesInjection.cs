using Cores.Features.Academics.Courses;
using Cores.Features.Academics.Departments;
using Cores.Features.Academics.Prerequisites;
using Cores.Features.Auth;
using Cores.Features.Commons;
using Cores.Features.Persons.Students;
using Shares.Helpers;

namespace Interfaces.Builders;

public static class ServicesInjection
{
    public static void InjectServices(this IServiceCollection services)
    {
        #region Token Helper

        services.AddScoped<TokenHelper>();

        #endregion

        #region Auth

        services.AddScoped<IAuthService, AuthService>();

        #endregion

        #region Commons

        services.AddScoped<ICommonService, CommonService>();

        #endregion

        #region Academics

        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IPrerequisiteService, PrerequisiteService>();

        #endregion

        #region Persons

        services.AddScoped<IStudentService, StudentService>();

        #endregion
    }
}