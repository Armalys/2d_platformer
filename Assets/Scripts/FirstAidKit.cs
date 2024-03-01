using UnityEngine;
using static Tags;

public class FirstAidKit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Player.ToString()))
        {
            Destroy(gameObject);
        }
    }
}