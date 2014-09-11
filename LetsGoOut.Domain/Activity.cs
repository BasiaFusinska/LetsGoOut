using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoOut.Domain
{
    public class Activity
    {
        public int ActivityId { get; private set; }
        public string Name { get; set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
    }
}
