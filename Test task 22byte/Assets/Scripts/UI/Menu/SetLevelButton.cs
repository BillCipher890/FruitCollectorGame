using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private int _currentButtonNumber;

    private void Start()
    {
        GlobalEventManager.OnMenu += SetLevelButtonInteractible;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnMenu -= SetLevelButtonInteractible;
    }

    public void SetLevelButtonInteractible()
    {
        if (_currentButtonNumber == 1)
            _button.interactable = !GlobalData.IsUnlockLevel1Enabled;
        else if (_currentButtonNumber == 2 && GlobalData.CurrentMoney >= GlobalData.UnlockLevel2Price)
            _button.interactable = !GlobalData.IsUnlockLevel2Enabled;
        else if (_currentButtonNumber == 3 && GlobalData.CurrentMoney >= GlobalData.UnlockLevel3Price)
            _button.interactable = !GlobalData.IsUnlockLevel3Enabled;
    }

    public void SetLevelButtonInteractible(int num)
    {
        if (_currentButtonNumber == 1 + num)
            _button.interactable = !GlobalData.IsUnlockLevel1Enabled;
        else if (_currentButtonNumber == 2 + num && GlobalData.CurrentMoney >= GlobalData.UnlockLevel2Price)
            _button.interactable = !GlobalData.IsUnlockLevel2Enabled;
        else if (_currentButtonNumber == 3 + num && GlobalData.CurrentMoney >= GlobalData.UnlockLevel3Price)
            _button.interactable = !GlobalData.IsUnlockLevel3Enabled;
    }
}
