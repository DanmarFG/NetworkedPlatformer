using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public NetworkVariable<int> Lives = new NetworkVariable<int>(3);

    bool canGethit = true;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        PlayerRespawn();
        SetColorBasedOnOwner();
    }

    public void PlayerHit()
    {
        Lives.Value -= 1;
        PlayerRespawn();
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }

    public void PlayerRespawn()
    {
        SetSpawnPointBasedOnId();
        StartCoroutine(GracePeriod(3f));
    }

    public IEnumerator GracePeriod(float timeInvuln)
    {
        canGethit = false;
        yield return new WaitForSeconds(timeInvuln);
        canGethit = true;
    }

    void SetSpawnPointBasedOnId()
    {
        transform.position = SpawnController.Instance.GetSpawnPoint((int)OwnerClientId).position;
    }

    void SetColorBasedOnOwner()
    {
        UnityEngine.Random.InitState((int)OwnerClientId);
        GetComponentInChildren<Renderer>().material.color = UnityEngine.Random.ColorHSV();
    }
}
