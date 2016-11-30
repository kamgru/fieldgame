using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Tests.Mocks
{
    public class PlayerInventoryDummy : IPlayerInventory
    {
        public void EarnGold(float amount)
        {            
        }

        public bool SpendGold(float amount)
        {
            return false; 
        }
    }
}
