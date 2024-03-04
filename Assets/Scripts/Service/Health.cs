using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Heal))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private Attack _attack;
    private Heal _heal;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Awake()
    {
        _attack = GetComponent<Attack>();
        _heal = GetComponent<Heal>();
    }

    private void OnEnable()
    {
        _attack.TakeDamageEvent += TakeDamage;
        _heal.HealEvent += Heal;
    }

    private void OnDisable()
    {
        _attack.TakeDamageEvent -= TakeDamage;
        _heal.HealEvent -= Heal;
    }

    private void TakeDamage()
    {
        int damage = 1;

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