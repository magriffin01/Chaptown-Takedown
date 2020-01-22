using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Health : MonoBehaviour
{
    public int startingHealthP2 = 100;
    public int currentHealthP2;
    public Slider healthSliderP2;
    public Image damageImageP2;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Animator animator;


    P2Movement player2Movement;
    //Player1Combat player1Combat;

    bool isDead;
    bool damaged;

    // Start is called before the first frame update
    void Awake()
    {
        player2Movement = GetComponent<P2Movement>();
        currentHealthP2 = startingHealthP2;
        damaged = false;
        isDead = false;
        //player1Combat = GetComponent<Player1Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            animator.SetTrigger("p2Hit");
            damageImageP2.color = flashColor;
        }

        else
        {
            damageImageP2.color = Color.Lerp(damageImageP2.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        damaged = true;
        currentHealthP2 -= amount;
        healthSliderP2.value = currentHealthP2;

        if (currentHealthP2 <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        player2Movement.enabled = false;
        //player1Combat.enabled = false;
    }
}
