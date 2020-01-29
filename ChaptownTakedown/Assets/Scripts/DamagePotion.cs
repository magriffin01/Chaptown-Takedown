using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePotion : MonoBehaviour
{
	public LayerMask player1Layers;
	public LayerMask player2Layers;
	Player1Combat player1Combat;
	Player2Combat player2Combat;
	Bullet bullet;
	public Transform potionTerritory;
	public int damageIncrease;

	void Start()
	{
		player1Combat = GetComponent<Player1Combat>();
		bullet = GetComponent<Bullet>();
	}

	void Update()
	{ 
		Collider2D[] enterHealthZone1 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player1Layers);
		foreach (Collider2D player in enterHealthZone1)
		{
			DamageUp();
		}

		Collider2D[] enterHealthZone2 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player2Layers);
		foreach (Collider2D player in enterHealthZone2)
		{
			DamageUp();
		}
	}

	void DamageUp()
	{
		Collider2D[] enterPlayer1 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player1Layers);
		foreach (Collider2D player in enterPlayer1)
		{
			Destroy(gameObject);
			Player1Combat player1Damage = player.GetComponent<Player1Combat>();
			player1Damage.attackDamage += damageIncrease;
		}

		Collider2D[] enterPlayer2 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player2Layers);
		foreach (Collider2D player in enterPlayer2)
		{
			Destroy(gameObject);
			Bullet player2Damage = player.GetComponent<Bullet>();
			player2Damage.bulletDamage += damageIncrease;
		}
	}

}
