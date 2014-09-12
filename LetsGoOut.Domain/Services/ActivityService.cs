using System;
using System.Data.Entity;
using System.Linq;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Extensions;
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
            var roundUp = DateTime.Now.RoundUp();
            return new CreateActivityModel { StartAt = roundUp, EndAt = roundUp.AddHours(1) };
        }

        public void CreateActivity(CreateActivityModel createActivityModel)
        {
            //TODO: Check if there are any links that time and rewire them

            _context.Set<Activity>().Add(new Activity(createActivityModel.Name,
                                                      createActivityModel.StartAt,
                                                      createActivityModel.EndAt,
                                                      createActivityModel.ActivityType));
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
            activity.SetValues(editActivityModel.Name,
                               editActivityModel.StartAt,
                               editActivityModel.EndAt,
                               editActivityModel.ActivityType);
        }

        public MoveActivityModel MoveActivityModel(MoveActivityRequest moveActivityRequest)
        {
            return new MoveActivityModel { ActivityId = moveActivityRequest.ActivityId};
        }
        public void Move(MoveActivityModel moveActivityModel)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == moveActivityModel.ActivityId);
            activity.Move(moveActivityModel.Offset);
        }
    }
}
