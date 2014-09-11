using System;
using System.Data.Entity;
using System.Linq;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Handlers
{
    public class EditActivityHandler : IHandler<EditActivityModel>,
                                       IRequestHandler<EditActivityRequest, EditActivityModel>
    {
        private readonly DbContext _context;

        public EditActivityHandler(DbContext context)
        {
            _context = context;
        }
        public void Handle(EditActivityModel editActivityModel)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == editActivityModel.ActivityId);
            activity.SetValues(editActivityModel.Name,
                               editActivityModel.StartAt,
                               editActivityModel.EndAt,
                               editActivityModel.ActivityType);
        }

        public EditActivityModel Handle(EditActivityRequest editActivityRequest)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == editActivityRequest.ActivityId);
            return new EditActivityModel
            {
                ActivityId = activity.ActivityId,
                Name = activity.Name,
                StartAt = activity.StartAt,
                EndAt = activity.EndAt,
                ActivityType = activity.ActivityType
            };
        }
    }
}
