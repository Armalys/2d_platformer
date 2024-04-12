using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public void Awake()
    {
        SetMaxHealth();
    }

    public void Update()
    {
        _textMesh.text = $"{_currentHealth} / {_maxHealth}";
    }

    public void Attack()
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= 1;
        }
    }

    public void Heal()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += 1;
        }
    }

    private void SetMaxHealth()
    {
        _currentHealth = _maxHealth;
        _textMesh.text = $"{_currentHealth} / {_maxHealth}";
    }
}