using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUISetChildren : MonoBehaviour
{
    [SerializeField]
    private WinResultTextChanger _winResTextChanger;

    public void WinResultTextChange()
    {
        _winResTextChanger.SetText(GlobalData.CurrentMaxFruitCount);
    }
}
