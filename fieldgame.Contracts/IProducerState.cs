﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fieldgame.Contracts
{
    public interface IProducerState
    {
        string Name { get; }
        void OnTick();
        void OnMouseDown();
    }
}
