using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Scripts.Upgrade
{
    public abstract class BaseUpgrade : MonoBehaviour
    {
        protected abstract int UpgradeCostFormula(int cost, int level);
        protected abstract int UpgradeValueFormula(int value, int level);
        public event Action OnUpgraded;
        
        [Header("Core")]
        [SerializeField] protected Observer observer;
        protected BankService bankService;
        
        [Header("Parameters")]
        [SerializeField] protected int value;
        [SerializeField] protected int level;
        [SerializeField] protected int cost;
        
        [Header("UI")]
        [SerializeField] protected Button upgradeButton;
        [SerializeField] protected TMP_Text levelValueText;
        [SerializeField] protected TMP_Text costValueText;
        [SerializeField] protected TMP_Text valueValueText;
        
        private int defaultValue;
        private int defaultCost;
        private int defaultLevel;

        protected virtual void Awake()
        {
            bankService = observer.GetBankService();
            
            upgradeButton.onClick.AddListener(OnClickButtonUpgrade);
            
            defaultValue = value;
            defaultCost = cost;
            defaultLevel = level;
        }

        protected virtual void OnDestroy()
        {
            upgradeButton.onClick.RemoveListener(OnClickButtonUpgrade);
        }

        private void OnClickButtonUpgrade()
        {
            if (TryUpgrade())
            {
                UpdateUI();
            }
        }

        private bool TryUpgrade()
        {
            if(bankService.Money < cost)
                return false;
            
            bankService.Buy(cost);
            level++;
            cost = UpgradeCostFormula(defaultCost, level);
            value = UpgradeValueFormula(value, level);
            
            Debug.Log($"Value: {value}; Level: {level}; Cost: {cost}");
            
            OnUpgraded?.Invoke();
            
            UpdateUI();
            return true;
        }

        public virtual void Reset()
        {
            value = defaultValue;
            level = defaultLevel;
            cost = defaultCost;
            OnUpgraded?.Invoke();
            UpdateUI();
        }

        public void UpdateUI()
        {
            levelValueText.text = $"{level} ур.";
            costValueText.text = cost.ToString();
            valueValueText.text = $"+ {value}";
        }
        
        public int GetValue() => value == 0 ? 1 : value;

        public void addaBankMoney(int money)
        {
            bankService.AddMoney(money);
        }
    }
}