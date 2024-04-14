using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public event Action<int> TakeDamageEvent;

    private int _defaultDamage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Enemy enemy) || other.collider.TryGetComponent(out Player player))
        {
            TakeDamageEvent?.Invoke(_defaultDamage);
        }
    }
}