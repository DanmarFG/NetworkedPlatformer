using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Transform> spawnPoints;

    public Transform GetSpawnPoint(int i)
    {
        return spawnPoints[i];
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, 1)];
    }
}
