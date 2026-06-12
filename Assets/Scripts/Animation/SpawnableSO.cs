using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableSO", menuName = "Scriptable Objects/SpawnableSO")]
public class SpawnableSO : ScriptableObject
{
    [SerializeField] public int seed = 42;

    [SerializeField] private List<GameObject> _spawnables;

    public GameObject GetRandomGameObject()
    {
        return _spawnables[Random.Range(0, _spawnables.Count)];
    }
}
