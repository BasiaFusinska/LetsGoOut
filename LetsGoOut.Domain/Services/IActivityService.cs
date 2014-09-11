using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Services
{
    public interface IActivityService
    {
        CreateActivityModel CreateActivityModel(CreateActivityRequest createActivityRequest);
        void CreateActivity(CreateActivityModel createActivityModel);
        EditActivityModel EditActivityModel(EditActivityRequest editActivityRequest);
        void EditActivity(EditActivityModel editActivityModel);
        MoveActivityModel MoveActivityModel(MoveActivityRequest moveActivityRequest);
        void Move(MoveActivityModel moveActivityModel);
    }
}
