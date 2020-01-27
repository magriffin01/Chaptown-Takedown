using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    public Animator animator;
    public Transform enemyAttackPoint;
    public Transform enemyTerritory;
    public float enemyAttackRange = 1f;
    public LayerMask player1Layers;
    public LayerMask player2Layers;
    public int enemyAttackDamage = 10;
    public float enemyAttackDelay = 1f;

    EnemyHealth enemyHealth;
    Player1Health player1Health;
    Player2Health player2Health;
    private float enemyAttackTimer;

    //Physics2D.OverlapCircleAll(enemyTerritory.position, enemyAttackRange, playerLayers);
    //   public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player1Health = GetComponent<Player1Health>();
        player2Health = GetComponent<Player2Health>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAttackTimer = 0;
        //Collider2D[]enterTerritory = Physics2D.OverlapCircleAll(enemyTerritory.position, enemyAttackRange, playerLayers);
    }

    // Update is called once per frame
    void Update()
    {
        enemyAttackTimer += Time.deltaTime;
        Collider2D[] enterTerritory1 = Physics2D.OverlapCircleAll(enemyTerritory.position, enemyAttackRange, player1Layers);
        foreach (Collider2D player in enterTerritory1)
        {
            if (enemyHealth.currentHealth > 0 && enemyAttackTimer >= enemyAttackDelay)
            {
                Attack();
            }

            else
            {
                Rest();
            }
        }

        Collider2D[] enterTerritory2 = Physics2D.OverlapCircleAll(enemyTerritory.position, enemyAttackRange, player2Layers);
        foreach (Collider2D player in enterTerritory2)
        {
            if (enemyHealth.currentHealth > 0 && enemyAttackTimer >= enemyAttackDelay)
            {
                Attack();
            }

            else
            {
                Rest();
            }
        }
    }


    void Attack()
    {
		animator.SetTrigger("enemyAttack");
        enemyAttackTimer = 0;
        Collider2D[]hitPlayer1 = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, player1Layers);
        foreach(Collider2D player in hitPlayer1)
        {
            player.GetComponent<Player1Health>().TakeDamage(enemyAttackDamage);
            // how do I make both players vulnerable to enemy damage independently?
            // i.e. can I make them both lose health in a way that doesn't force them both to lose health when just one is attacked?
        }

        Collider2D[]hitPlayer2 = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, player2Layers);
        foreach (Collider2D player in hitPlayer2)
        {
            player.GetComponent<Player2Health>().TakeDamage(enemyAttackDamage);
        }
    }


    public void Rest()
    {

    }

    void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }
}
