using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Tests.Mocks
{
    internal class StateDummy : IProducerState
    {
        public void OnMouseDown()
        {
            throw new NotImplementedException();
        }

        public void OnTick()
        {
            throw new NotImplementedException();
        }
    }
}
