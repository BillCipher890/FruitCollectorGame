using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody _rigidbody;

    private Coroutine _moveCoroutine;

    [HideInInspector]
    public Vector3 startPlayerPosition;
    [HideInInspector]
    public Quaternion startPlayerRotation;

    void Start()
    {
        startPlayerPosition = transform.position;
        startPlayerRotation = transform.rotation;

        GlobalEventManager.OnDeath += StopMoveCoroutine;
        GlobalEventManager.OnWin += Win;
        GlobalEventManager.OnRetry += OnRetry;
        StartMove();
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnDeath -= StopMoveCoroutine;
        GlobalEventManager.OnWin -= Win;
        GlobalEventManager.OnRetry -= OnRetry;
    }

    public void StartMove()
    {
        _moveCoroutine = StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            _rigidbody.MovePosition(transform.position + _speed * transform.forward / 50);
            yield return new WaitForFixedUpdate();
        }
    }

    private void Win(int money)
    {
        StopMoveCoroutine();
    }

    private void StopMoveCoroutine()
    {
        StopCoroutine(_moveCoroutine);
    }

    private void OnRetry()
    {
        transform.position = startPlayerPosition;
        transform.rotation = startPlayerRotation;
        StartMove();
    }
}
