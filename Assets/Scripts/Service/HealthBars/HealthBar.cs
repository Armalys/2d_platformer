using UnityEngine;

namespace Service.HealthBars
{
    public abstract class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;

        protected int MaxHealth => _health.MaxHealth;
        protected int CurrentHealth => _health.CurrentHealth;

        private void Awake()
        {
            SetHealth();
        }

        private void OnEnable()
        {
            _health.HealthChangedEvent += ChangeHealth;
        }

        private void OnDisable()
        {
            _health.HealthChangedEvent -= ChangeHealth;
        }

        protected abstract void ChangeHealth();
        protected abstract void SetHealth();
    }
}