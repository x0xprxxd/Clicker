using System;
using UnityEngine;

namespace _Project.Code.Scripts.Upgrade
{
    public class UpgradeController : MonoBehaviour
    {
        private int clickPower;
        
        [Header("Сила клика")]
        [SerializeField] private ClickPowerUpgrade clickPowerUpgrade;
        
        [Header("Монеты в секунду")]
        [SerializeField] private PerSecondUpgrade perSecondUpgrade;

        private void Awake()
        {
            clickPower = clickPowerUpgrade.GetValue();
            
            clickPowerUpgrade.OnUpgraded += UpdateClickPower;
            
            clickPowerUpgrade.UpdateUI();
            perSecondUpgrade.UpdateUI();
        }

        private void OnDestroy()
        {
            clickPowerUpgrade.OnUpgraded -= UpdateClickPower;
        }
        
        private void UpdateClickPower()
        {
            clickPower = clickPowerUpgrade.GetValue();
        }
        
        public int Click() => clickPower;
        
        public void Reset()
        {
            clickPowerUpgrade.Reset();
            perSecondUpgrade.Reset();
        }
    }
}
