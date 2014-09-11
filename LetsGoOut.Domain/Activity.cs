using System;

namespace LetsGoOut.Domain
{
    public class Activity
    {
        public int ActivityId { get; private set; }
        public string Name { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
        public int ActivityType { get; private set; }

        protected Activity()
        { }

        public Activity(string name, DateTime startAt, DateTime endAt, int activityType)
        {
            SetValues(name, startAt, endAt, activityType);
        }

        public void SetValues(string name, DateTime startAt, DateTime endAt, int activityType)
        {
            Name = name;
            StartAt = startAt;
            EndAt = endAt;
            ActivityType = activityType;
        }

        public void Move(TimeSpan offset)
        {
            StartAt = StartAt.Add(offset);
            EndAt = EndAt.Add(offset);
        }
    }
}
