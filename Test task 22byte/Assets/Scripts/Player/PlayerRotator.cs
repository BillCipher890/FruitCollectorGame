using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    private void Start()
    {
        PlayerEventManager.OnSwipe += Swipe;
    }

    private void OnDestroy()
    {
        PlayerEventManager.OnSwipe -= Swipe;
    }

    private void Swipe(Vector2 direction)
    {
        if (direction.x > 0)
        {
            // Right rotate.
            var rotate = Quaternion.FromToRotation(_rigidbody.transform.forward, _rigidbody.transform.right);
            _rigidbody.MoveRotation(_rigidbody.rotation * rotate);
        }
        else
        {
            // Left rotate.
            var rotate = Quaternion.FromToRotation(_rigidbody.transform.forward, -1 * _rigidbody.transform.right);
            _rigidbody.MoveRotation(_rigidbody.rotation * rotate);
        }
    }
}
