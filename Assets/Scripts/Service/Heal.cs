using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Action HealedEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<FirstAidKit>())
        {
            HealedEvent?.Invoke();
        }
    }
}