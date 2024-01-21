using TMPro;
using UnityEngine;

public class SetLevelUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelText;

    public void SetLevelText(int level)
    {
        _levelText.SetText(string.Format("LVL{0}", level));
    }
}
