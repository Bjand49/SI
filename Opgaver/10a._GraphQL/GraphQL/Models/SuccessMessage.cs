namespace GraphQL.Models
{
    public class SuccessMessage
    {
        public SuccessMessage(string message) { 
            Message = message;
        }
        public string Message { get; set; }
    }
}
