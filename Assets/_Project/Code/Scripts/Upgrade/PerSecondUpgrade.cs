using System;
using System.Collections;
using UnityEngine;

namespace _Project.Code.Scripts.Upgrade
{
    public class PerSecondUpgrade : BaseUpgrade
    {
        private float interval = 1.0f;
        private Coroutine coroutine;
        
        protected override int UpgradeCostFormula(int cost, int level) => (int)(cost * Math.Pow(1.23f, level));

        protected override int UpgradeValueFormula(int value, int level) {
            if (level <= 1 || value == 0) return 1;
            return (int)Math.Ceiling(level * Math.Pow(1.08f, level - 1));
        }

        protected override void Awake()
        {
            base.Awake();
            OnUpgraded += TryStartCoroutine;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            OnUpgraded -= TryStartCoroutine;
            StopCoroutine();
        }
        
        public override void Reset()
        {
            StopCoroutine();
            base.Reset();
            if (level > 0)
            {
                TryStartCoroutine();
            }
            UpdateUI();
        }

        private void TryStartCoroutine()
        {
            if (level > 0 && coroutine == null)
                StartCoroutine();
        }
        
        private void StartCoroutine()
        {
            if(coroutine != null)
                return;
            
            coroutine = StartCoroutine(PerSecondFunc());
        }

        private void StopCoroutine()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
        
        private IEnumerator PerSecondFunc()
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                bankService.AddMoney(value);
            }
        }
    }
}
