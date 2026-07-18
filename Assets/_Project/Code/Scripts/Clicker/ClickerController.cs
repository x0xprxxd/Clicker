using System;
using _Project.Code.Scripts.Upgrade;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Scripts
{
    public class ClickerController : MonoBehaviour
    {
        private int clickerCounter;
        
        [Header("Core")]
        [SerializeField] protected Observer observer;
        protected BankService bankService;
    
        [Header("UI")]
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button clickButton;
        [SerializeField] private Button resetButton;
    
        [Header("Controllers")]
        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private UpgradeController upgradeController;
    
        private void Awake()
        {
            bankService = observer.GetBankService();
            bankService.OnMoneyChanged += OnMoneyChanged;
            
            clickButton.onClick.AddListener(OnClickIncrementMoney);
            resetButton.onClick.AddListener(OnClickResetGame);
        }

        private void OnDestroy()
        {
            clickButton.onClick.RemoveListener(OnClickIncrementMoney);
            resetButton.onClick.RemoveListener(OnClickResetGame);
        }

        private void OnClickIncrementMoney()
        {
            bankService.AddMoney(upgradeController.Click());
            clickerCounter++;
            //backgroundController.UpdateBackground(clickerCounter);
            UpdateUI();
        }
    
        private void OnClickResetGame()
        {
            upgradeController.Reset();
            bankService.Reset();
            clickerCounter = 0;
            //backgroundController.UpdateBackground(clickerCounter);
            UpdateUI();
        }

        private void OnMoneyChanged(int money)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = bankService.Money.ToString();
        }
    }
}
