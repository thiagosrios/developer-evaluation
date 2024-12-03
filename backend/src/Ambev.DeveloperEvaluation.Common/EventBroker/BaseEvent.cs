namespace Ambev.DeveloperEvaluation.Common.EventBroker
{
    public class BaseEvent<Event>
    {
        public string Message { get; set; }
        public Event Data { get; set; }

        public BaseEvent(Event data, string message)
        {
            Data = data;
            Message = message;
        }
    }
}
