using System;

namespace LetsGoOut.Domain.DTOs
{
    public class MoveActivityModel
    {
        public int ActivityId { get; set; }
        public TimeSpan Offset { get; set; }
    }
}
