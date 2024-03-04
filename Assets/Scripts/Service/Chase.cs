using UnityEngine;

[RequireComponent(typeof(PlayerDetected))]
public class Chase : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private PlayerDetected _playerDetected;

    public void Awake()
    {
        _playerDetected = GetComponent<PlayerDetected>();
    }

    private void OnEnable()
    {
        _playerDetected.PlayerDetectedEvent += MoveTowardsPlayer;
    }

    private void OnDestroy()
    {
        _playerDetected.PlayerDetectedEvent -= MoveTowardsPlayer;
    }

    private void MoveTowardsPlayer(float playerPositionX)
    {
        Vector2 targetPosition = new Vector2(playerPositionX, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
    }
}