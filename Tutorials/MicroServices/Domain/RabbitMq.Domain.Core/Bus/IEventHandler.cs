using RabbitMq.Domain.Core.Events;
using System.Threading.Tasks;

namespace RabbitMq.Domain.Core
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle (TEvent @event);
    }

    public interface IEventHandler
    {
        // MARK-UP
    }
}