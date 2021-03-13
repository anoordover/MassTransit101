using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes;
using MassTransit.Courier;
using Sample.Contracts;

namespace Sample.Components.StateMachines.OrderStateMachineActivities
{
    public class AcceptOrderActivity
        : Activity<OrderState, OrderAccepted>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateScope("accept-order");
        }

        public void Accept(StateMachineVisitor visitor)
        {
            visitor.Visit(this);
        }

        public async Task Execute(BehaviorContext<OrderState, OrderAccepted> context, Behavior<OrderState, OrderAccepted> next)
        {
            Console.WriteLine("Hello, World. Order is {0}", context.Data.OrderId);
            await next.Execute(context);
        }

        public Task Faulted<TException>(BehaviorExceptionContext<OrderState, OrderAccepted, TException> context, Behavior<OrderState, OrderAccepted> next) where TException : Exception
        {
            return next.Faulted(context);
        }
    }
}