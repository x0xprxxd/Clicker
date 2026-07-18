using System;

namespace _Project.Code.Scripts.Upgrade
{
    public class ClickPowerUpgrade : BaseUpgrade
    {
        protected override int UpgradeCostFormula(int cost, int level) => (int)(cost * Math.Pow(1.23f, level));
        protected override int UpgradeValueFormula(int value, int level) => (int)Math.Ceiling(value * 1.15f);
    }
}