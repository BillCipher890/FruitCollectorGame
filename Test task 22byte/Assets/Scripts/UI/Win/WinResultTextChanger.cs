using TMPro;
using UnityEngine;

public class WinResultTextChanger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void SetText(int money)
    {
        text.SetText(string.Format("You sell fruits and gain {0}$", money));
    }
}
