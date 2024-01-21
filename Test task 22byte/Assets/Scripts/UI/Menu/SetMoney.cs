using TMPro;
using UnityEngine;

public class SetMoney : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _moneyText;
    public void SetCurrentMoney()
    {
        _moneyText.SetText(string.Format("{0}$", GlobalData.CurrentMoney));
    }
}
