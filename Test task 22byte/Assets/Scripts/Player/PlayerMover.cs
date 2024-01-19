using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody _rigidbody;

    private Coroutine _moveCoroutine;

    void Start()
    {
        GlobalEventManager.OnDeath += Death;
        _moveCoroutine = StartCoroutine(Move());
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnDeath -= Death;
    }

    IEnumerator Move()
    {
        while (true)
        {
            _rigidbody.MovePosition(transform.position + _speed * transform.forward / 50);
            yield return new WaitForFixedUpdate();
        }
    }

    private void Death()
    {
        StopCoroutine(_moveCoroutine);
    }
}
