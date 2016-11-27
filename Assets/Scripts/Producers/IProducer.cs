using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace kmgr.fieldgame.Producers
{
    public interface IProducer
    {
        float Progress { get; set; }
        float ProductionSpeed { get; set; }
        float ProductionValue { get; set; }
        ProducerStateEnum ProducerState { get; set; }
    }
}
