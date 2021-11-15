namespace Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public int Value { get; set; }
        public string Message { get; set; }
        public ResponseMessage(int value, string message)
        {
            Value = value;
            Message = message;
        }
    }
}