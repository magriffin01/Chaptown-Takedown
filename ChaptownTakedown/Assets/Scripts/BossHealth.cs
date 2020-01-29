using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public Animator animator;

	public int maxHealth = 100;
	public int currentHealth;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		// Play hurt animation
		animator.SetTrigger("bossHit");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("Boss died!");
		Destroy(gameObject);
	}
}
