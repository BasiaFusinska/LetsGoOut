namespace LetsGoOut.Domain.DTOs
{
    public class CreateLinkModel : ICommand
    {
        public int LinkType { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
