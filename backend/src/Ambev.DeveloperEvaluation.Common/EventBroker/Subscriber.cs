using Ambev.DeveloperEvaluation.Common.EventBroker;

namespace Ambev.DeveloperEvaluation.Domain.Events.Subscribers
{
    public class Subscriber<TModel>
    {
        protected readonly IEventBroker _eventBroker;
        public BaseEvent<TModel>? Event {  get; set; }

        public Subscriber(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
            eventBroker.Subscribe<BaseEvent<TModel>>(HandleMessage);
        }

        private void HandleMessage(BaseEvent<TModel> systemEvent)
        {
            Event = systemEvent;
            var type = typeof(TModel).Name;
            var created = systemEvent.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[EVENT] {created} | {type} | Message received: {systemEvent.Message}");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
