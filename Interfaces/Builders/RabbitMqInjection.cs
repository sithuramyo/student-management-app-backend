using MassTransit;
using Shares.Services;

namespace Interfaces.Builders;

public static class RabbitMqInjection
{
    public static void AddRabbitMqInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ChatMessageConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMq"));
                cfg.ReceiveEndpoint("chat-messages", e =>
                {
                    e.ConfigureConsumer<ChatMessageConsumer>(context);
                    e.PrefetchCount = 16;
                    e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                });
            });
        });
    }
}