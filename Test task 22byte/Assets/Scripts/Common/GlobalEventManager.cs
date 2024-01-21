using System;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static event Action<int> OnGetFruit;

    public static event Action<int> OnGetCurrentMaxFruitCount;

    public static event Action OnDeath;

    public static event Action<int> OnWin;

    public static event Action OnRetry;

    public static event Action OnMenu;

    public static void SendOnGetFruit(int fruitNumber)
    {
        OnGetFruit?.Invoke(fruitNumber);
    }

    public static void SendOnGetCurrentMaxFruitCount(int maxFruitCount)
    {
        OnGetCurrentMaxFruitCount?.Invoke(maxFruitCount);
    }

    public static void SendOnDeath()
    {
        OnDeath?.Invoke();
    }

    public static void SendOnWin(int money)
    {
        OnWin?.Invoke(money);
    }

    public static void SendOnRetry()
    {
        OnRetry?.Invoke();
    }

    public static void SendOnMenu()
    {
        OnMenu?.Invoke();
    }
}
