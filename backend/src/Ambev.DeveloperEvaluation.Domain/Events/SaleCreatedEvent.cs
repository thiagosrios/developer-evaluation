using Ambev.DeveloperEvaluation.Common.EventBroker;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent : BaseEvent<Sale>
    {
        public Sale? Sale { get; set; }

        public SaleCreatedEvent(Sale sale, string message) : base(sale, message)
        { 
        }
    }

    public class SaleCreatedEventSubscriber
    {
        protected readonly IEventBroker _eventBroker;

        public SaleCreatedEventSubscriber(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
            eventBroker.Subscribe<SaleCreatedEvent>(HandleMessage);
        }

        private static void HandleMessage(SaleCreatedEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Message received: {message.Message}");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
