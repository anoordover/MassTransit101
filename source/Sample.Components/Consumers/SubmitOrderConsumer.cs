using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Sample.Contracts;

namespace Sample.Components.Consumers
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        private readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.Log(LogLevel.Debug, "SubmitOrderConsumer: {CustomerNumber}",
                context.Message.CustomerNumber);
            if (context.Message.CustomerNumber.Contains("TEST"))
            {
                if (context.RequestId != null)
                    await context.RespondAsync<OrderSubmissionRejected>(new
                    {
                        context.Message.OrderId,
                        InVar.Timestamp,
                        context.Message.CustomerNumber,
                        Reason = $"Test customer cannot submit orders: {context.Message.CustomerNumber}"
                    });
                return;
            }

            await context.Publish<OrderSubmitted>(
                new
                {
                    context.Message.OrderId,
                    context.Message.Timestamp,
                    context.Message.CustomerNumber
                });
            
            if (context.RequestId != null)
                await context.RespondAsync<OrderSubmissionAccepted>(new
                {
                    InVar.Timestamp,
                    context.Message.OrderId,
                    context.Message.CustomerNumber
                });
        }
    }
}