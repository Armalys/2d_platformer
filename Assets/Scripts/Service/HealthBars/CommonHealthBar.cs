using Service.HealthBars;
using UnityEngine;
using UnityEngine.UI;

public class CommonHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    protected override void ChangeHealth()
    {
        _slider.value = CurrentHealth;
    }

    protected override void SetUp()
    {
        _slider.maxValue = MaxHealth;
        _slider.value = CurrentHealth;
    }
}