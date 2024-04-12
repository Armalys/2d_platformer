using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Service.HealthBars
{
    public class SmoothHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _speedFillBar;

        public void Awake()
        {
            SetMaxHealth();
        }

        public void Attack()
        {
            if (_slider.value > _slider.minValue)
            {
                StartCoroutine(ChangeHealth(_slider.value - 1f));
            }
        }

        public void Heal()
        {
            if (_slider.value < _slider.maxValue)
            {
                StartCoroutine(ChangeHealth(_slider.value + 1f));
            }
        }

        private void SetMaxHealth()
        {
            _slider.maxValue = _maxHealth;
            _slider.value = _maxHealth;
        }

        private IEnumerator ChangeHealth(float targetHealth)
        {
            while (Mathf.Approximately(_slider.value, targetHealth) == false)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _speedFillBar * Time.deltaTime);

                yield return null;
            }
        }
    }
}