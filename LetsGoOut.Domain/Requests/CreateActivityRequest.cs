﻿using System;

namespace LetsGoOut.Domain.Requests
{
    public class CreateActivityRequest
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int ActivityType { get; set; }
    }
}
