using System;
using Service.Buttons;
using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Heal))]
public class Health : MonoBehaviour
{
    [SerializeField] public int MaxHealth;
    [SerializeField] public int CurrentHealth;

    public Action HealthChangedEvent;

    private Attack _attack;
    private Heal _heal;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Awake()
    {
        _attack = GetComponent<Attack>();
        _heal = GetComponent<Heal>();
    }

    private void OnEnable()
    {
        _attack.TakeDamageEvent += TakeDamage;
        _heal.HealedEvent += Heal;
    }

    private void OnDisable()
    {
        _attack.TakeDamageEvent -= TakeDamage;
        _heal.HealedEvent -= Heal;
    }

    private void TakeDamage(int damage = 1)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        HealthChangedEvent?.Invoke();

        if (CurrentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Heal(int heal = 10)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0, MaxHealth);
        HealthChangedEvent?.Invoke();
    }
}