using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float _swipeThreshold;

    private Vector2 _downPosition;
    private Vector2 _upPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _downPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _upPosition = eventData.position;
        Swipe();
    }

    private void Swipe()
    {
        if (Mathf.Abs(_downPosition.x - _upPosition.x) < _swipeThreshold)
            return;

        PlayerEventManager.SendOnSwipe(_upPosition - _downPosition);
    }
}
