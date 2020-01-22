using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Health : MonoBehaviour
{
    public int startingHealthP1 = 100;
    public int currentHealthP1;
    public Slider healthSliderP1;
    public Image damageImageP1;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	public Animator animator;

	P1Movement player1Movement;
    Player1Combat player1Combat;
    

    bool isDead;
    bool damaged;

    // Start is called before the first frame update
    void Awake()
    {
        player1Movement = GetComponent<P1Movement>();
        player1Combat = GetComponent<Player1Combat>();
        damaged = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
			animator.SetTrigger("p1Hit");
			damageImageP1.color = flashColor;
        }

        else
        {
            damageImageP1.color = Color.Lerp(damageImageP1.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {   if (isDead)
        {
            return;
        }

        damaged = true;
        currentHealthP1 -= amount;
        healthSliderP1.value = currentHealthP1;

        if(currentHealthP1 <=0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        player1Movement.enabled = false;
        player1Combat.enabled = false;
    }
}
