using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float bulletSpeed;

    public void SetActive(Vector2 position, bool goingRight)
    {
        transform.position = position;

        if (goingRight)
            rb.linearVelocity = Vector2.right * bulletSpeed;
        else
            rb.linearVelocity = -Vector2.right * bulletSpeed;

        gameObject.SetActive(true);

        StartCoroutine(DespawnTimer(3f));
    }

    public IEnumerator DespawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
