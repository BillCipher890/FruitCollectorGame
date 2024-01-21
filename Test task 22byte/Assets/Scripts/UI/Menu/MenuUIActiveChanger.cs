using System.Collections;
using UnityEngine;

public class MenuUIActiveChanger : MonoBehaviour
{
    [SerializeField]
    private MenuSetChildren _menuSetChildren;

    private void Start()
    {
        GlobalEventManager.OnRetry += Deactivate;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnRetry -= Deactivate;
    }

    public void Activate()
    {
        transform.gameObject.SetActive(true);
        StartCoroutine(SendOnMenuCoroutine());
        _menuSetChildren.SetMoney();
    }

    IEnumerator SendOnMenuCoroutine()
    {
        yield return new WaitForEndOfFrame();
        GlobalEventManager.SendOnMenu();
    }

    public void Deactivate()
    {
        transform.gameObject.SetActive(false);
    }
}
