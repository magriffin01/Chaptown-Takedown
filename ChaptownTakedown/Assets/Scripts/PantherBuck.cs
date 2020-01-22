using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantherBuck : MonoBehaviour
{
    public int buckValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(buckValue);
        }

    }
}
