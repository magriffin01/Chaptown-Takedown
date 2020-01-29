using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTerritory : MonoBehaviour
{
	public Animator animator;
	public Transform bossAttackPoint;
	public Transform bossTerritory;
	public float bossAttackRange = 1f;
	public LayerMask player1Layers;
	public LayerMask player2Layers;
	public int bossAttackDamage = 15;
	public float bossAttackDelay = 1f;

	BossHealth bossHealth;
	Player1Health player1Health;
	Player2Health player2Health;
	private float bossAttackTimer;

	//Physics2D.OverlapCircleAll(enemyTerritory.position, enemyAttackRange, playerLayers);
	//   public Transform target;

	// Start is called before the first frame update
	void Start()
	{
		player1Health = GetComponent<Player1Health>();
		player2Health = GetComponent<Player2Health>();
		bossHealth = GetComponent<BossHealth>();
		bossAttackTimer = 0;
		//Collider2D[]enterTerritory = Physics2D.OverlapCircleAll(enemyTerritory.position, enemyAttackRange, playerLayers);
	}

	// Update is called once per frame
	void Update()
	{
		bossAttackTimer += Time.deltaTime;
		Collider2D[] enterTerritory1 = Physics2D.OverlapCircleAll(bossTerritory.position, bossAttackRange, player1Layers);
		foreach (Collider2D player in enterTerritory1)
		{
			if (bossHealth.currentHealth > 0 && bossAttackTimer >= bossAttackDelay)
			{
				Attack();
			}

			else
			{
				Rest();
			}
		}

		Collider2D[] enterTerritory2 = Physics2D.OverlapCircleAll(bossTerritory.position, bossAttackRange, player2Layers);
		foreach (Collider2D player in enterTerritory2)
		{
			if (bossHealth.currentHealth > 0 && bossAttackTimer >= bossAttackDelay)
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
		animator.SetTrigger("bossAttack");
		bossAttackTimer = 0;
		Collider2D[] hitPlayer1 = Physics2D.OverlapCircleAll(bossAttackPoint.position, bossAttackRange, player1Layers);
		foreach (Collider2D player in hitPlayer1)
		{
			player.GetComponent<Player1Health>().TakeDamage(bossAttackDamage);
			// how do I make both players vulnerable to enemy damage independently?
			// i.e. can I make them both lose health in a way that doesn't force them both to lose health when just one is attacked?
		}

		Collider2D[] hitPlayer2 = Physics2D.OverlapCircleAll(bossAttackPoint.position, bossAttackRange, player2Layers);
		foreach (Collider2D player in hitPlayer2)
		{
			player.GetComponent<Player2Health>().TakeDamage(bossAttackDamage);
		}
	}


	public void Rest()
	{

	}

	void OnDrawGizmosSelected()
	{
		if (bossAttackPoint == null)
			return;

		Gizmos.DrawWireSphere(bossAttackPoint.position, bossAttackRange);
	}
}
