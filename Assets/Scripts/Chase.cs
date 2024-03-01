using UnityEngine;
using static Tags;

public class Chase : MonoBehaviour
{
    [SerializeField] private float _raycastDistance = 10f;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _player;

    private Vector2 patrolDirection = Vector2.right;

    private void Update()
    {
        patrolDirection = _rb.velocity.x < 0 ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, patrolDirection, _raycastDistance, _playerLayer);

        Debug.DrawRay(transform.position, patrolDirection * _raycastDistance, Color.green);

        if (hit.collider != null && hit.collider.CompareTag(Player.ToString()))
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 targetPosition = new Vector2(_player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
    }
}