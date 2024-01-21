using UnityEngine;

public class FailUIActiveChanger : MonoBehaviour
{
    void Start()
    {
        GlobalEventManager.OnRetry += Deactivate;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnRetry -= Deactivate;
    }

    public void Deactivate()
    {
        transform.gameObject.SetActive(false);
    }

    public void Activate()
    {
        transform.gameObject.SetActive(true);
    }
}
