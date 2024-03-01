using System;
using UnityEngine;
using static Tags;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PivotPoint.ToString()))
        {
            _speed *= -1f;
            _spriteRenderer.flipX = _speed > 0;
        }
    }

    private void FixedUpdate()
    {
        string xVelocity = "xVelocity";

        _rb.velocity = new Vector2(_speed, 0);
        _animator.SetFloat(xVelocity, Math.Abs(_rb.velocity.x));
    }
}