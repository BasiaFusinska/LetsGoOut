namespace LetsGoOut.Domain.Requests
{
    public class CreateLinkRequest : IRequest
    {
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
