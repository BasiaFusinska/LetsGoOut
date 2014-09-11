using System;

namespace LetsGoOut.Domain.DTOs
{
    public class MoveActivityModel : ICommand
    {
        public int ActivityId { get; set; }
        public TimeSpan Offset { get; set; }
    }
}
