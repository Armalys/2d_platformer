using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Action<int> HealedEvent;

    private int _defaultHeal = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out FirstAidKit firstAidKit) && other.TryGetComponent(out Player player) )
        {
            HealedEvent?.Invoke(_defaultHeal);
        }
    }
}