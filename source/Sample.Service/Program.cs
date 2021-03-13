using MassTransit;
using MassTransit.Definition;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Sample.Components.Consumers;
using Sample.Components.StateMachines;

namespace Sample.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
                    services.AddMassTransit(cfg =>
                    {
                        cfg.AddConsumersFromNamespaceContaining<SubmitOrderConsumer>();
                        cfg.UsingRabbitMq(ConfigureBus);
                        cfg.AddSagaStateMachine<OrderStateMachine, OrderState>(typeof(OrderStateMachineDefinition))
                            .RedisRepository();
                    });
                    services.AddMassTransitHostedService();
                });

        private static void ConfigureBus(IBusRegistrationContext context,
            IRabbitMqBusFactoryConfigurator configurator)
        {
            configurator.ConfigureEndpoints(context, KebabCaseEndpointNameFormatter.Instance);
        }
    }
}