using System.Data.Entity;
using LetsGoOut.Domain.DTOs;
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

        public CreateLinkModel CreateLinkModel(CreateLinkRequest createLinkRequest)
        {
            return new CreateLinkModel {Previous = createLinkRequest.Previous, Next = createLinkRequest.Next};
        }

        public void CreateLink(CreateLinkModel createLinkModel)
        {
            _context.Set<Link>().Add(new Link
            {
                LinkType = createLinkModel.LinkType,
                Previous = createLinkModel.Previous,
                Next = createLinkModel.Next
            });
        }
    }
}
