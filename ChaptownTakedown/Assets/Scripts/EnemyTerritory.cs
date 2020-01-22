using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    public BoxCollider2D territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject enemy;
    //BasicEnemy basicenemy;
    EnemyHealth enemyHealth;
    Player1Health player1Health;
    Player2Health player2Health;

    public Transform target;
    public float speed = 3f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;


    // Start is called before the first frame update
    void Start()
    {
        player1Health = GetComponent<Player1Health>();
        player2Health = GetComponent<Player2Health>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTerritory == true && enemyHealth.currentHealth > 0)
        {
            MoveToPlayer();
            Attack();
        }

        if (playerInTerritory == false)
        {
            Rest();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTerritory = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTerritory = false;
        }
    }

    void Attack()
    {
        if (player1Health.currentHealthP1 > 0)
        {
            player1Health.TakeDamage(attack1Damage);
        }

        if (player2Health.currentHealthP2 > 0)
        {
            player2Health.TakeDamage(attack1Damage);
        }
    }


    public void MoveToPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) > attack1Range)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
    }

    public void Rest()
    {

    }
}
