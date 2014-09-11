using System;

namespace LetsGoOut.Domain.DTOs
{
    public class CreateActivityModel : ICommand
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int ActivityType { get; set; }
    }
}
