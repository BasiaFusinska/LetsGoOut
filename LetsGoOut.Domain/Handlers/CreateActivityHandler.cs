using System.Data.Entity;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Handlers
{
    public class CreateActivityHandler : IHandler<CreateActivityModel>, 
                                         IRequestHandler<CreateActivityRequest, CreateActivityModel>
    {
        private readonly DbContext _context;

        public CreateActivityHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(CreateActivityModel createActivityModel)
        {
            _context.Set<Activity>().Add(new Activity(createActivityModel.Name,
                                                      createActivityModel.StartAt,
                                                      createActivityModel.EndAt,
                                                      createActivityModel.ActivityType));
        }

        public CreateActivityModel Handle(CreateActivityRequest request)
        {
            return new CreateActivityModel();
        }
    }
}
