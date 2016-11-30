using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fieldgame.Core
{
    public class Producer
    {
        public string Name { get; set; }
        public float CurrentProgress { get; set; }
        public float TickValue { get; set; }
        public float ProductionValue { get; set; }
    }
}
