using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public void OnTryAgainButton()
    {
        GlobalEventManager.SendOnRetry();
    }
}
