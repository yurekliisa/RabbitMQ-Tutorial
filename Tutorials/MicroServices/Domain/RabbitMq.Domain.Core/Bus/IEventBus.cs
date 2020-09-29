using RabbitMq.Domain.Core.Commands;
using RabbitMq.Domain.Core.Events;
using System.Threading.Tasks;

namespace RabbitMq.Domain.Core
{
    public interface IEventBus {
        Task SendCommand<T> (T command) where T : Command;
        void Publish<T> (T @event) where T : Event;

        void Subscribe<T, TH> ()
                where T : Event
                where TH : IEventHandler<T>;

    }
}