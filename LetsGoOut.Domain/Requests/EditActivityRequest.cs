using System;

namespace LetsGoOut.Domain.Requests
{
    public class EditActivityRequest : IRequest
    {
        public int ActivityId { get; set; }
    }
}
