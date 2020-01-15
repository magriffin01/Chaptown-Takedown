using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantherBuck : MonoBehaviour
{
    public int buckValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player 1"))
        {
            //ScoreManager.instance.ChangeScore(buckValue);
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            //ScoreManager.instance.ChangeScore(buckValue);
        }
    }
}
