using UnityEngine;

public class WinUIActivateChanger : MonoBehaviour
{
    [SerializeField]
    private WinUISetChildren wUISC;
    [SerializeField]
    private WinUISaveData wUISD;

    public void Activate()
    {
        transform.gameObject.SetActive(true);
        wUISC.WinResultTextChange();
        wUISD.SaveData();
    }

    public void Deactivate()
    {
        transform.gameObject.SetActive(false);
    }
}
