using System.Data.Entity;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Services
{
    public class LinkService : ILinkService
    {
        private readonly DbContext _context;

        public LinkService(DbContext context)
        {
            _context = context;
        }

        public void CreateLink(CreateLinkRequest createLinkRequest)
        {
            _context.Set<Link>().Add(new Link
            {
                LinkType = createLinkRequest.LinkType,
                Previous = createLinkRequest.Previous,
                Next = createLinkRequest.Next
            });
        }
    }
}
