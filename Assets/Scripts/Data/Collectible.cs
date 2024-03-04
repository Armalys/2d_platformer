using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Action<GameObject> CollectEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            CollectEvent?.Invoke(gameObject);
        }
    }
}