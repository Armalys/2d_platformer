using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Patrol))]
public class PlayerDetected : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _raycastDistance = 4f;

    private Vector2 _patrolDirection = Vector2.right;
    private Rigidbody2D _rigidbody;
    private Patrol _patrol;

    public event Action<float> PlayerDetectedEvent;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _patrol = GetComponent<Patrol>();
    }

    private void OnEnable()
    {
        _patrol.ChangeDirectionEvent += ChangeDirection;
    }

    private void OnDestroy()
    {
        _patrol.ChangeDirectionEvent -= ChangeDirection;
    }

    private void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _patrolDirection, _raycastDistance, _playerLayer);

        Debug.DrawRay(transform.position, _patrolDirection * _raycastDistance, Color.green);

        if (hit.collider != null && hit.collider.GetComponent<Player>() != null)
        {
            float playerPositionX = hit.collider.GetComponent<Player>().transform.position.x;
            PlayerDetectedEvent?.Invoke(playerPositionX);
        }
    }

    private void ChangeDirection()
    {
        _patrolDirection = _rigidbody.velocity.x < 0 ? Vector2.right : Vector2.left;
    }
}