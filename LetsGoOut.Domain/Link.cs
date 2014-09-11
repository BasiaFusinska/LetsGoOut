namespace LetsGoOut.Domain
{
    public class Link
    {
        public int LinkId { get; private set; }
        public int LinkType { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
