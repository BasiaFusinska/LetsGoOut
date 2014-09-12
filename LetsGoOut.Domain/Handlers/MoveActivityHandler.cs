using System;
using System.Data.Entity;
using System.Linq;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;

namespace LetsGoOut.Domain.Handlers
{
    public class MoveActivityHandler: IHandler<MoveActivityModel>,
                                      IRequestHandler<MoveActivityRequest, MoveActivityModel>
    {
        private readonly DbContext _context;

        public MoveActivityHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(MoveActivityModel moveActivityModel)
        {
            var activity = _context.Set<Activity>().FirstOrDefault(a => a.ActivityId == moveActivityModel.ActivityId);
            activity.Move(TimeSpan.FromMinutes(30*moveActivityModel.Offset));
        }

        public MoveActivityModel Handle(MoveActivityRequest moveActivityRequest)
        {
            return new MoveActivityModel { ActivityId = moveActivityRequest.ActivityId };

        }
    }
}
