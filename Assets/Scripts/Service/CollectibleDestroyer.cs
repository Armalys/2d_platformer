using UnityEngine;

[RequireComponent(typeof(Collectible))]
public class CollectibleDestroyer : MonoBehaviour
{
    private Collectible _collectible;

    public void Awake()
    {
        _collectible = GetComponent<Collectible>();
    }

    private void OnEnable()
    {
        _collectible.CollectEvent += Destroy;
    }

    private void OnDestroy()
    {
        _collectible.CollectEvent -= Destroy;
    }
}