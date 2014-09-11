using System;
using System.Data.Entity;
using System.Linq;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Services
{
    public class ActivityService : IActivityService
    {
        private readonly DbContext _context;

        public ActivityService(DbContext context)
        {
            _context = context;
        }

        public CreateActivityModel CreateActivityModel(CreateActivityRequest createActivityRequest)
        {
            return new CreateActivityModel();
        }

        public void CreateActivity(CreateActivityModel createActivityModel)
        {
            //TODO: Check if there are any links that time and rewire them

            _context.Set<Activity>().Add(new Activity
            {
                Name = createActivityModel.Name,
                StartAt = createActivityModel.StartAt,
                EndAt = createActivityModel.EndAt,
                ActivityType = createActivityModel.ActivityType
            });
        }

        public EditActivityModel EditActivityModel(EditActivityRequest editActivityRequest)
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

        public void EditActivity(EditActivityModel editActivityModel)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == editActivityModel.ActivityId);
            activity.Name = editActivityModel.Name;
            activity.StartAt = editActivityModel.StartAt;
            activity.EndAt = editActivityModel.EndAt;
            activity.ActivityType = editActivityModel.ActivityType;
        }

        public MoveActivityModel MoveActivityModel(MoveActivityRequest moveActivityRequest)
        {
            return new MoveActivityModel { ActivityId = moveActivityRequest.ActivityId};
        }
        public void Move(MoveActivityModel moveActivityModel)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == moveActivityModel.ActivityId);

            activity.StartAt = activity.StartAt.Add(moveActivityModel.Offset);
            activity.EndAt = activity.EndAt.Add(moveActivityModel.Offset);
        }
    }
}
