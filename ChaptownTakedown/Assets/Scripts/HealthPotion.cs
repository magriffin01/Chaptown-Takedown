using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public LayerMask player1Layers;
    public LayerMask player2Layers;
    Player1Health player1Health;
    Player2Health player2Health;
    public Transform potionTerritory;

    void Start()
    {
        player1Health = GetComponent<Player1Health>();
        player2Health = GetComponent<Player2Health>();
    }

    void Update()
    {
        Collider2D[] enterHealthZone1 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player1Layers);
        foreach (Collider2D player in enterHealthZone1)
        {
            HealthUp();
        }

        Collider2D[] enterHealthZone2 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player2Layers);
        foreach (Collider2D player in enterHealthZone2)
        {
            HealthUp();
        }
    }

    void HealthUp()
    {
        Collider2D[] enterPlayer1 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player1Layers);
        foreach (Collider2D player in enterPlayer1)
        {
            Destroy(gameObject);
            player.GetComponent<Player1Health>().TakeDamage(-10);
        }

        Collider2D[] enterPlayer2 = Physics2D.OverlapCircleAll(potionTerritory.position, 1, player2Layers);
        foreach (Collider2D player in enterPlayer2)
        {
            Destroy(gameObject);
            player.GetComponent<Player2Health>().TakeDamage(-10);
        }
    }
}
