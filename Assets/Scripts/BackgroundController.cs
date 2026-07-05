using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Color[] colors;
    [SerializeField] private int[] _porog;
    //private int[] _porog = { 0, 10, 20, 30, 40, 50 };

    private void Awake()
    {
        backgroundImage.color = colors[0];
    }

    public void UpdateBackground(int clickerCounter)
    {
        if (clickerCounter >= _porog[_porog.Length - 1])
        {
            backgroundImage.color = colors[colors.Length - 1];
            return;
        }
        
        for (int i = 0; i < _porog.Length; i++)
        {
            if(_porog[i] == clickerCounter)
            {
                backgroundImage.color = colors[i];
                break;
            }
        }
    }
}
