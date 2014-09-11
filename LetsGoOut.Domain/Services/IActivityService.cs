using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Services
{
    public interface IActivityService
    {
        void CreateActivity(CreateActivityRequest createActivityRequest);
        EditActivityRequest GetActivity(int activityId);
        void EditActivity(EditActivityRequest editActivityRequest);
    }
}
