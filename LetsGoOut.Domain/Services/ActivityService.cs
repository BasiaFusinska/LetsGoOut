using System;
using System.Data.Entity;
using System.Linq;
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

        public void CreateActivity(CreateActivityRequest createActivityRequest)
        {
            //TODO: Check if there are any links that time and rewire them

            _context.Set<Activity>().Add(new Activity
            {
                Name = createActivityRequest.Name,
                StartAt = createActivityRequest.StartAt,
                EndAt = createActivityRequest.EndAt,
                ActivityType = createActivityRequest.ActivityType
            });
        }

        public EditActivityRequest GetActivity(int activityId)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == activityId);
            return new EditActivityRequest
            {
                ActivityId = activity.ActivityId,
                Name = activity.Name,
                StartAt = activity.StartAt,
                EndAt = activity.EndAt,
                ActivityType = activity.ActivityType
            };
        }

        public void EditActivity(EditActivityRequest editActivityRequest)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == editActivityRequest.ActivityId);
            activity.Name = editActivityRequest.Name;
            activity.StartAt = editActivityRequest.StartAt;
            activity.EndAt = editActivityRequest.EndAt;
            activity.ActivityType = editActivityRequest.ActivityType;
        }

        public void Move(MoveActivityRequest moveActivityRequest)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == moveActivityRequest.ActivityId);

            activity.StartAt = activity.StartAt.Add(moveActivityRequest.Offset);
            activity.EndAt = activity.EndAt.Add(moveActivityRequest.Offset);
        }
    }
}
