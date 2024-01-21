using System.Collections;
using UnityEngine;

public class WinUISaveData : MonoBehaviour
{
    public void SaveData()
    {
        SaveMoney();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", GlobalData.CurrentMoney);
    }
}
