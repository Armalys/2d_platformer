using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Action TakeDamageEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() || other.GetComponent<Player>())
        {
            TakeDamageEvent?.Invoke();
        }
    }
}