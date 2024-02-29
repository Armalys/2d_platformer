using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float horizontal;

    private void Update()
    {
        horizontal = Input.GetAxis(Horizontal);
        JumpUp();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        string xVelocity = "xVelocity";

        _rb.velocity = new Vector2(horizontal * _moveSpeed, _rb.velocity.y);
        _animator.SetFloat(xVelocity, Math.Abs(_rb.velocity.x));
        Flip();
    }

    private bool IsGrounded()
    {
        float radius = 0.2f;
        return Physics2D.OverlapCircle(_groundCheck.position, radius, _groundLayer);
    }

    private void JumpUp()
    {
        if (Input.GetButtonDown(Jump) && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void Flip()
    {
        _spriteRenderer.flipX = _rb.velocity.x < 0f;
    }
}