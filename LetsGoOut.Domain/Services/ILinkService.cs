using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Services
{
    public interface ILinkService
    {
        CreateLinkModel CreateLinkModel(CreateLinkRequest createLinkRequest);
        void CreateLink(CreateLinkModel createLinkModel);
    }
}
