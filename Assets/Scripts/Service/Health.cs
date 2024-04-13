using System;
using Service.Buttons;
using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Heal))]
public class Health : MonoBehaviour
{
    [SerializeField] public int MaxHealth;
    [SerializeField] public int CurrentHealth;

    [SerializeField] private DamageButton _damageButton;
    [SerializeField] private HealButton _healButton;

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
        _damageButton.TakeDamageEvent += TakeDamage;
        _heal.HealedEvent += Heal;
        _healButton.HealEvent += Heal;
    }

    private void OnDisable()
    {
        _attack.TakeDamageEvent -= TakeDamage;
        _damageButton.TakeDamageEvent -= TakeDamage;
        _healButton.HealEvent -= Heal;
    }

    private void TakeDamage()
    {
        int damage = 1;

        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        HealthChangedEvent?.Invoke();

        if (CurrentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Heal()
    {
        CurrentHealth = Mathf.Clamp(MaxHealth, 0, MaxHealth);
        HealthChangedEvent?.Invoke();
    }
}