using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float Speed = 5;
    public float JumpForce = 5;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if(!IsOwner) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsSpawned) return;

        var multiplier = Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.parent.transform.position += new Vector3(-multiplier, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.parent.transform.position += new Vector3(multiplier, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.parent.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(transform.parent.GetComponent<Rigidbody2D>().linearVelocity.x, JumpForce, 0);
        }
    }
}
