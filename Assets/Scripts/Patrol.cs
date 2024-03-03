using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;

    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _raycastDistance = 10f;

    private Vector2 _patrolDirection = Vector2.right;

    public event Action playerDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PivotPoint>())
        {
            ChangeDirection();
        }
    }

    private void Update()
    {
        FindPlayer();
    }

    private void FixedUpdate()
    {
        string xVelocity = "xVelocity";

        _rigidbody.velocity = new Vector2(_speed, 0);
        _animator.SetFloat(xVelocity, Math.Abs(_rigidbody.velocity.x));
    }

    private void FindPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _patrolDirection, _raycastDistance, _playerLayer);

        Debug.DrawRay(transform.position, _patrolDirection * _raycastDistance, Color.green);

        if (hit.collider != null && hit.collider.GetComponent<Player>() != null)
        {
            playerDetected?.Invoke();
        }
    }

    private void ChangeDirection()
    {
        _speed *= -1f;
        _spriteRenderer.flipX = _speed > 0;
        _patrolDirection = _speed > 0 ? Vector2.right : Vector2.left;
        ;
    }
}