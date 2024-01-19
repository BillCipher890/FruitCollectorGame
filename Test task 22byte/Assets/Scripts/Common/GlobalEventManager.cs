using System;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static event Action<int> OnGetFruit;

    public static event Action OnDeath;

    public static event Action OnWin;

    public static void SendOnGetFruit(int fruitNumber)
    {
        OnGetFruit?.Invoke(fruitNumber);
    }

    public static void SendOnDeath()
    {
        OnDeath?.Invoke();
    }

    public static void SendOnWin()
    {
        OnWin?.Invoke();
    }
}
