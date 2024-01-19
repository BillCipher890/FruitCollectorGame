using UnityEngine;
using UnityEngine.UI;

public class FruitColorGridChanger : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Image[] _buttonImages;

    public void SwapFruit(int num)
    {
        Color swapColor = _image.color;
        _image.color = _buttonImages[num].color;
        _buttonImages[num].color = swapColor;
    }
}
