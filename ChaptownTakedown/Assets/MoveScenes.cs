using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    public string mainMenu;

    void OnTriggerEnter2D(Collider2D other)
	{
        if(other.CompareTag("Player1"))
		{
            SceneManager.LoadScene(mainMenu);
		}
	}

}
