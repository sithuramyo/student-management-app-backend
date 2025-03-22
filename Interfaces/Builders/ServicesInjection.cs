using Interfaces.Features.Academics.Departments;
using Interfaces.Features.Auth;
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

        #region Academics

        services.AddScoped<IDepartmentService, DepartmentService>();

        #endregion
    }
}