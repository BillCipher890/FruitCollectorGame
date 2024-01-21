using UnityEngine;

public class MenuSetChildren : MonoBehaviour
{
    [SerializeField]
    private SetMoney _setMoney;

    public void SetMoney()
    {
        _setMoney.SetCurrentMoney();
    }
}
