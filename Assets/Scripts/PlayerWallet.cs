using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Assertions;
using fieldgame.Contracts;
using System;

namespace kmgr.fieldgame
{
    public class PlayerWallet : MonoBehaviour, IPlayerInventory
    {
        [SerializeField]
        private Text goldTextControl;

        private float gold;

        private void Start()
        {
            Assert.IsNotNull(goldTextControl);
        }

        public void EarnGold(float amount)
        {
            gold += amount;
            UpdateText();
        }

        public void SpendGold(int amount)
        {
            gold -= amount;
            UpdateText();
        }

        private void UpdateText()
        {
            goldTextControl.text = gold.ToString();
        }

        public bool SpendGold(float amount)
        {
            throw new NotImplementedException();
        }
    }
}
