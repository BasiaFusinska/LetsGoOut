﻿using System;

namespace LetsGoOut.Domain
{
    public class Activity
    {
        public int ActivityId { get; private set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int ActivityType { get; set; }
    }
}
