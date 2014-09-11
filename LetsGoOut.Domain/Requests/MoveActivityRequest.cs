using System;

namespace LetsGoOut.Domain.Requests
{
    public class MoveActivityRequest : IRequest
    {
        public int ActivityId { get; set; }
    }
}
