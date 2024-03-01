using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform _itemPool;
    [SerializeField] private GameObject _template;

    private Transform[] _spawnLocations;

    private void Start()
    {
        _spawnLocations = new Transform[_itemPool.childCount];

        for (int i = 0; i < _itemPool.childCount; i++)
        {
            _spawnLocations[i] = _itemPool.GetChild(i);
        }

        foreach (Transform spawnLocation in _spawnLocations)
        {
            Instantiate(_template, spawnLocation.position, Quaternion.identity);
        }
    }
}