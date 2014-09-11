using System;

namespace LetsGoOut.Domain.Requests
{
    public class MoveActivityRequest
    {
        public int ActivityId { get; set; }
        public TimeSpan Offset { get; set; }
    }
}
