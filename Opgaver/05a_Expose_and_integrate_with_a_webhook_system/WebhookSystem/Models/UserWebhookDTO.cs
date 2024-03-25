namespace WebhookSystem.Models
{
    public class UserWebhookDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Url { get; set; }
        public string HTTPMethod { get; set; }
        public List<string> Events { get; set; }
        internal List<WebhookType> EventTypes
        {
            get
            {
                return Events.Select(x => Enum.Parse<WebhookType>(x, true)).ToList();
            }
        }
        internal HTTPType HTTPMethodEnum
        {
            get
            {
                return Enum.Parse<HTTPType>(HTTPMethod, true);
            }
        }
    }
}
