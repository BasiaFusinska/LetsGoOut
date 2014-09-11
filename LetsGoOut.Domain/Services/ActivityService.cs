using System;
using System.Data.Entity;
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
            _context.Set<Activity>().Add(new Activity
            {
                Name = createActivityRequest.Name,
                StartAt = createActivityRequest.StartAt,
                EndAt = createActivityRequest.EndAt,
                ActivityType = createActivityRequest.ActivityType
            });
        }
    }
}
