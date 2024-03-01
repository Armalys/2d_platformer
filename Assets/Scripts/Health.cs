using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Enemy.ToString()) || other.CompareTag(Tags.Player.ToString()))
        {
            int damage = 1;
            TakeDamage(damage);
        }
        else if (other.CompareTag(Tags.FirstAidKit.ToString()))
        {
            Heal();
        }
    }

    private void TakeDamage(int damage)
    {
        if (_currentHealth > damage)
        {
            _currentHealth -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Heal()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}