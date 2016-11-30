using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fieldgame.Contracts
{
    public interface IPlayerInventory
    {
        void EarnGold(float amount);
        bool SpendGold(float amount);
    }
}
