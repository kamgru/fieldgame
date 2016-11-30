using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Core
{
    public class PlayerInventory : IPlayerInventory
    {
        public float Gold { get { return gold; } }
        private float gold;
        public PlayerInventory() : this(0f) { }
        public PlayerInventory(float startingGold) 
        {
            gold = startingGold;
        }

        public void EarnGold(float amount)
        {
            gold += amount;
        }

        public bool SpendGold(float amount)
        {
            if (gold >= amount)
            {
                gold -= amount;
                return true;
            }
            return false;
        }
    }
}
