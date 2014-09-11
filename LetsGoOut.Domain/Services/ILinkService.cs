using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Services
{
    public interface ILinkService
    {
        void CreateLink(CreateLinkRequest createLinkRequest);
    }
}
