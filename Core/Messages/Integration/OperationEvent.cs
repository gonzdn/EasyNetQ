namespace Core.Messages.Integration
{
    public class OperationEvent : IntegrationEvent
    {
        public int Number { get; set; }
        public string Operation { get; set; }
        public OperationEvent(int number, string operation)
        {
            Number = number;
            Operation = operation;
        }
    }
}
