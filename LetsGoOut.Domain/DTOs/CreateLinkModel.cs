namespace LetsGoOut.Domain.DTOs
{
    public class CreateLinkModel
    {
        public int LinkType { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
