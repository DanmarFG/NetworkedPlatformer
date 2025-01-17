using Unity.Netcode;
using UnityEngine;

public class ClientSetSpawnPoint : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        SetSpawnPointBasedOnId();
    }

    void SetSpawnPointBasedOnId()
    {
        transform.position = SpawnController.Instance.GetSpawnPoint((int)OwnerClientId).position;
    }
}
