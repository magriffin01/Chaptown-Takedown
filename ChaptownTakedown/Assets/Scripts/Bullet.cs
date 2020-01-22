using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int bulletDamage = 30;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }

}

