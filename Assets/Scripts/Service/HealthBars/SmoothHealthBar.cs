using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Service.HealthBars
{
    public class SmoothHealthBar : HealthBar
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _speedFillBar;

        private Coroutine _coroutine;

        private void Update()
        {
            ChangeHealth();
        }

        protected override void ChangeHealth()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeHealth(CurrentHealth));
        }

        protected override void SetHealth()
        {
            _slider.maxValue = MaxHealth;
            _slider.value = CurrentHealth;
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