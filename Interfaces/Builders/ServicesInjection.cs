using Cores.Features.Academics.AcademicTerms;
using Cores.Features.Academics.ClassSchedules;
using Cores.Features.Academics.CourseOfferings;
using Cores.Features.Academics.Courses;
using Cores.Features.Academics.Departments;
using Cores.Features.Academics.Prerequisites;
using Cores.Features.Auth;
using Cores.Features.Commons;
using Cores.Features.Communications;
using Cores.Features.Persons.Faculties;
using Cores.Features.Persons.Students;
using Cores.Features.Persons.SystemUsers;
using Infrastructures.DataModels.Communications;
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
        services.AddScoped<IAcademicTermService, AcademicTermService>();
        services.AddScoped<ICourseOfferingService, CourseOfferingService>();
        services.AddScoped<IClassScheduleService, ClassScheduleService>();

        #endregion

        #region Persons

        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IFacultyService, FacultyService>();
        services.AddScoped<ISystemUserService, SystemUserService>();

        #endregion

        #region Communication
        services.AddScoped<IChatService, ChatService>();
        #endregion
    }
}