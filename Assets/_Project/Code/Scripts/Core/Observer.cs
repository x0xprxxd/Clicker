using UnityEngine;

namespace _Project.Code.Scripts
{
    [DefaultExecutionOrder(-100)]
    public class Observer : MonoBehaviour
    {
        private BankService bankService;

        private void Awake()
        {
            bankService = new BankService(0);
        }
        
        public BankService  GetBankService() => bankService;
    }
}
