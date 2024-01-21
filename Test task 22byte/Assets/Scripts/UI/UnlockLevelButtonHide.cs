using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevelButtonHide : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tmPro;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private int _numberOfButton;
    [SerializeField]
    private SetMoney setMoney;

    public void Hide(int cost)
    {
        if (GlobalData.CurrentMoney < cost)
            return;

        _tmPro.SetText("");
        _image.color = new Color(0, 0, 0, 0);

        if (_numberOfButton == 1)
            GlobalData.IsUnlockLevel1Enabled = false;
        else if (_numberOfButton == 2)
            GlobalData.IsUnlockLevel2Enabled = false;
        else if (_numberOfButton == 3)
            GlobalData.IsUnlockLevel3Enabled = false;

        GlobalData.CurrentMoney -= cost;
        setMoney.SetCurrentMoney();

        PlayerPrefs.SetInt(string.Format("IsUnlockLevel{0}Enabled", _numberOfButton), 0);
        PlayerPrefs.Save();
    }
}
