namespace LetsGoOut.Domain
{
    public class Link
    {
        public int LinkId { get; private set; }
        public int LinkType { get; private set; }
        public int Previous { get; private set; }
        public int Next { get; private set; }

        protected Link()
        { }
        public Link(int linkType, int previous, int next)
        {
            SetValues(linkType, previous, next);
        }

        private void SetValues(int linkType, int previous, int next)
        {
            LinkType = linkType;
            Previous = previous;
            Next = next;
        }
    }
}
