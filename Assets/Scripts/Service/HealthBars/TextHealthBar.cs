using Service.HealthBars;
using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    protected override void ChangeHealth()
    {
        _textMesh.text = $"{CurrentHealth} / {MaxHealth}";
    }

    protected override void SetHealth()
    {
        _textMesh.text = $"{CurrentHealth} / {MaxHealth}";
    }
}