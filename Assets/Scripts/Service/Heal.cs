using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Action HealEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<FirstAidKit>())
        {
            HealEvent?.Invoke();
        }
    }
}