using System.Collections;
using UnityEngine;

namespace Service.Buttons.Abilitys
{
    public class HealthDrain : MonoBehaviour

    {
        [SerializeField] private float _auraRadius = 5f;
        [SerializeField] private float _duration = 6f;
        [SerializeField] private float _interval = 1f;
        [SerializeField] private int _drainDamage = 1;
        [SerializeField] private int _drainHeal = 1;

        private Player _player;
        private WaitForSeconds _wait;
        private Coroutine _coroutine;

        public void OnClick()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(StealHealth());
        }

        private IEnumerator StealHealth()
        {
            for (int i = 0; i < _duration; i++)
            {
                var colliders = Physics2D.OverlapCircleAll(transform.position, _auraRadius);

                foreach (var collider in colliders)
                {
                    if (collider.TryGetComponent(out Enemy enemy) && enemy.TryGetComponent(out Health health) &&
                        health.CurrentHealth > 0)
                    {
                        _player.TryGetComponent(out Heal heal);
                        heal.HealedEvent?.Invoke(_drainHeal);
                        enemy.TryGetComponent(out Attack attack);
                        attack.TakeDamageEvent?.Invoke(_drainDamage);
                    }
                }

                yield return _wait;
            }
        }

        private void Awake()
        {
            TryGetComponent(out _player);
            _wait = new WaitForSeconds(_interval);
        }
    }
}