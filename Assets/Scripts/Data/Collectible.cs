using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Action<GameObject> CollectEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            CollectEvent?.Invoke(gameObject);
        }
    }
}