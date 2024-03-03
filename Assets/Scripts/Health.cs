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
        if (other.GetComponent<Enemy>() || other.GetComponent<Player>())
        {
            int damage = 1;
            TakeDamage(damage);
        }
        else if (other.GetComponent<FirstAidKit>())
        {
            Heal();
        }
    }

    private void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Heal()
    {
        _currentHealth = Mathf.Clamp(_maxHealth, 0, _maxHealth);
    }
}