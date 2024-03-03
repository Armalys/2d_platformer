using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}