using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Scripts
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Color[] colors;
        [SerializeField] private int[] porog;

        private void Awake()
        {
            //backgroundImage.color = colors[0];
        }

        public void UpdateBackground(int clickerCounter)
        {
            if (clickerCounter >= porog[porog.Length - 1])
            {
                backgroundImage.color = colors[colors.Length - 1];
                return;
            }
        
            for (int i = 0; i < porog.Length; i++)
            {
                if(porog[i] == clickerCounter)
                {
                    backgroundImage.color = colors[i];
                    break;
                }
            }
        }
    }
}
