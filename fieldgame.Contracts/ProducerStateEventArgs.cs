using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fieldgame.Contracts
{
    public class ProducerStateEventArgs : EventArgs
    {
        public string CurrentStateName { get; private set; }

        public ProducerStateEventArgs(string stateName)
        {
            this.CurrentStateName = stateName;
        }
    }
}
