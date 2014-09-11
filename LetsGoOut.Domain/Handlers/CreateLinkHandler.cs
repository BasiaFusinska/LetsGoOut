using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Handlers
{
    public class CreateLinkHandler : IHandler<CreateLinkModel>,
                                     IRequestHandler<CreateLinkRequest, CreateLinkModel>
    {
        private readonly DbContext _context;

        public CreateLinkHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(CreateLinkModel createLinkModel)
        {
            _context.Set<Link>().Add(new Link(createLinkModel.LinkType,
                                              createLinkModel.Previous,
                                              createLinkModel.Next));        }

        public CreateLinkModel Handle(CreateLinkRequest createLinkRequest)
        {
            return new CreateLinkModel { Previous = createLinkRequest.Previous, Next = createLinkRequest.Next };

        }
    }
}
