using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edge : MonoBehaviour
{
    public Text WinText;
    public Button RestartButton;

    void OnCollisionEnter(Collision other)
	{
        WinText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
	}
}
