using System;

namespace LetsGoOut.ReadModel
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public TimeSpan Duration { get; set; }
        public int IsActivity { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
    }
}
