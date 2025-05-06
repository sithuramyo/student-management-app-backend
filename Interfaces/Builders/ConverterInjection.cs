using Shares.Converters;

namespace Interfaces.Builders;

public static class ConverterInjection
{
    public static void AddConverter(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
        });
    }
}