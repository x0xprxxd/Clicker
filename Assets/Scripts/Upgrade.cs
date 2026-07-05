using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public delegate int UpgradeCostFormula(int cost, int level);
    public delegate int UpgradeValueFormula(int value);
    
    [SerializeField] private int value;
    [SerializeField] private int cost;
    [SerializeField] private int level;

    private int _defaultValue;
    private int _defaultCost;
    private int _defaultLevel;

    void Awake()
    {
        _defaultValue = value;
        _defaultCost = cost;
        _defaultLevel = level;
    }

    public bool TryUpgrade(ref int score, UpgradeValueFormula valueFormula, UpgradeCostFormula costFormula)
    {
        if (score < cost)
            return false;

        score -= cost;
        level++;
        
        value = valueFormula(value);
        cost = costFormula(_defaultCost, level);
        
        Debug.Log($"Value: {value}; Level: {level}; Cost: {cost}");
        
        return true;
    }

    public void Reset()
    {
        value = _defaultValue;
        level = _defaultLevel;
        cost = _defaultCost;
    }
    
    public int GetValue() => value;
    public int GetCost() => cost;
    public int GetLevel() => level;
}
