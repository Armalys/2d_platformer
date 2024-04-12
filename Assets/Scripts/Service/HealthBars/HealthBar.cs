using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private int _maxHealth;

    public void Awake()
    {
        SetMaxHealth();
    }

    public void Attack()
    {
        if (_slider.value > _slider.minValue)
        {
            _slider.value -= 1;
        }
    }

    public void Heal()
    {
        if (_slider.value < _slider.maxValue)
        {
            _slider.value += 1;
        }
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _maxHealth;
        _slider.value = _maxHealth;
    }
}