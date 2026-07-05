using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    private int _score;
    private int _clickPower;
    private int _clickerCounter;
    
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button clickButton;
    [SerializeField] private Button resetButton;
    
    [SerializeField] private BackgroundController backgroundController;
    
    // Сила клика
    [SerializeField] private UpgradeWrapper clickUpgrade;
    private readonly Upgrade.UpgradeValueFormula _valueFormula = (value) => (int)Math.Ceiling(value * 1.15f);
    private readonly Upgrade.UpgradeCostFormula _costFormula = (cost, level) => (int)(cost * Math.Pow(1.23f, level));
    
    private void Awake()
    {
        clickButton.onClick.AddListener(OnClickIncrementScore);
        resetButton.onClick.AddListener(OnClickResetGame);
        _clickPower = clickUpgrade.GetValue();
    }

    private void OnDestroy()
    {
        clickButton.onClick.RemoveListener(OnClickIncrementScore);
        resetButton.onClick.RemoveListener(OnClickResetGame);
    }

    private void OnClickIncrementScore()
    {
        _score += _clickPower;
        _clickerCounter++;
        backgroundController.UpdateBackground(_clickerCounter);
        UpdateUI();
    }
    
    private void OnClickResetGame()
    {
        clickUpgrade.Reset();
        _score  = 0;
        _clickerCounter = 0;
        _clickPower = clickUpgrade.GetValue();
        backgroundController.UpdateBackground(_clickerCounter);
        UpdateUI();
    }

    public void ClickUpgrade()
    {
        if (clickUpgrade.TryUpgrade(ref _score, _valueFormula, _costFormula))
        {
            _clickPower = clickUpgrade.GetValue();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        scoreText.text = _score.ToString();
    }
}
