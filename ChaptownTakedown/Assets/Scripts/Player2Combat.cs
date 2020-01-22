using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Combat : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public LayerMask enemyLayers;

    public float shootRange = 1f;
    //public int shootDamage = 25;

    public float shootRate = 2f;
    float nextShootTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Shoot();
                nextShootTime = Time.time + 1f / shootRate;
            }
        }
    }

    void Shoot()
    {
        //Collider2D[] shootEnemies = Physics2D.OverlapCircleAll(firePoint.position, shootRange, enemyLayers);

        //foreach (Collider2D enemy in shootEnemies)
        //{
        //    enemy.GetComponent<EnemyHealth>().TakeDamage(shootDamage);
        //}

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        if (firePoint == null)
            return;

        Gizmos.DrawWireSphere(firePoint.position, shootRange);
    }

}


