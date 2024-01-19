using System;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public static event Action<Vector2> OnSwipe;

    public static void SendOnSwipe(Vector2 direction)
    {
        OnSwipe?.Invoke(direction);
    }
}
