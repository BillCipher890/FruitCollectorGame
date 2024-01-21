using UnityEngine;

public class GameplayUIActiveChanger : MonoBehaviour
{
    void Start()
    {
        GlobalEventManager.OnRetry += Activate;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnRetry -= Activate;
    }

    public void Activate()
    {
        transform.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        transform.gameObject.SetActive(false);
    }
}
