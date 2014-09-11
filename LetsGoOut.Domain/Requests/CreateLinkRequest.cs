namespace LetsGoOut.Domain.Requests
{
    public class CreateLinkRequest
    {
        public int LinkType { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
