using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Assets.Scripts
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField]
        private Text goldTextControl;

        private int gold;

        private void Start()
        {
            Assert.IsNotNull(goldTextControl);
        }

        public void AddGold(int amount)
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

    }
}
