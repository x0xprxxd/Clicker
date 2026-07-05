using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeWrapper : MonoBehaviour
{
    [SerializeField] private ClickerController clickerController;
    
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TMP_Text lvlText;
    [SerializeField] private TMP_Text costText;
    
    [SerializeField] private Upgrade upgrade;
    

    public int GetValue() => upgrade.GetValue();

    private void Awake()
    {
        upgradeButton.onClick.AddListener(OnClickButton);
        UpdateUI();
    }

    private void OnDestroy()
    {
        upgradeButton.onClick.RemoveListener(OnClickButton);
    }

    private void OnClickButton()
    {
        clickerController.ClickUpgrade();
    }

    private void UpdateUI()
    {
        lvlText.text = $"{upgrade.GetLevel()} ур.";
        costText.text = upgrade.GetCost().ToString();
    }

    public bool TryUpgrade(ref int score, Upgrade.UpgradeValueFormula valueFormula, Upgrade.UpgradeCostFormula costFormula)
    {
        bool result = upgrade.TryUpgrade(ref score, valueFormula, costFormula);
        if (result)
            UpdateUI();
        return result;
    }
    
    public void Reset()
    {
        upgrade.Reset();
        UpdateUI();
    }
}
