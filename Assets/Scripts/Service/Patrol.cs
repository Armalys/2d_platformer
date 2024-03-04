using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _patrolPointA;
    [SerializeField] private Transform _patrolPointB;

    private Transform _currentPatrolPoint;
    private float _distanceThreshold = 0.5f;

    public Action ChangeDirectionEvent;

    private void Start()
    {
        _currentPatrolPoint = _patrolPointA;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(_rigidbody.position, _currentPatrolPoint.position) < _distanceThreshold)
        {
            ChangeDirection();
        }

        MoveToPoint();
    }

    private void MoveToPoint()
    {
        _rigidbody.velocity =
            new Vector2(_speed * Mathf.Sign(_currentPatrolPoint.position.x - _rigidbody.position.x), 0);
    }

    private void ChangeDirection()
    {
        _currentPatrolPoint = _currentPatrolPoint == _patrolPointA ? _patrolPointB : _patrolPointA;
        ChangeDirectionEvent?.Invoke();
        _spriteRenderer.flipX = _currentPatrolPoint == _patrolPointA;
    }
}