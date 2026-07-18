using System;

namespace _Project.Code.Scripts
{
    public class BankService
    {
        public event Action<int> OnMoneyChanged;
        
        private int money;
        public int Money { 
            get => money;
            private set
            {
                if (money != value)
                {
                    money = value;
                    OnMoneyChanged?.Invoke(money);
                }
            } 
        }
        
        public BankService(int money)
        {
            Money = money;
        }

        public void Buy(int money)
        {
            if(Money >= money)
                Money -= money;
        }

        public void AddMoney(int money) => Money += money;
        
        public void Reset() => Money = 0;
    }
}
