using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetUnlockLevelButton : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField] 
    private TextMeshProUGUI text;
    [SerializeField]
    private int _currentButtonNumber;
    private void Start()
    {
        GlobalEventManager.OnMenu += SetUnockLevelButtonHiden;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnMenu -= SetUnockLevelButtonHiden;
    }

    private void SetUnockLevelButtonHiden()
    {
        if (_currentButtonNumber == 1)
        {
            if (!GlobalData.IsUnlockLevel1Enabled)
                Hide();
        }
        else if (_currentButtonNumber == 2)
        {
            if (!GlobalData.IsUnlockLevel2Enabled)
                Hide();
        }
        else if (_currentButtonNumber == 3)
        {
            if (!GlobalData.IsUnlockLevel3Enabled)
                Hide();
        }
    }

    private void Hide()
    {
        _image.color = new Color(0, 0, 0, 0);
        text.SetText("");
    }
}
