using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Chase : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _player;

    private Patrol _patrol;

    public void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }

    private void OnEnable()
    {
        _patrol.playerDetected += MoveTowardsPlayer;
    }

    private void OnDestroy()
    {
        _patrol.playerDetected -= MoveTowardsPlayer;
    }

    private void MoveTowardsPlayer()
    {
        Vector2 targetPosition = new Vector2(_player.position.x, transform.position.y);
        transform.position =
            Vector2.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
    }
}