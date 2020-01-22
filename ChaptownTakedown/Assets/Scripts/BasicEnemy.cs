using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        Rest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToPlayer()
    {
        transform.LookAt(target.position);
        if (Vector3.Distance(transform.position, target.position) > attack1Range)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    public void Rest()
    {

    }

}
