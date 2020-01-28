using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Touched");
        door.transform.position = new Vector2 (0, -1);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        door.transform.position = new Vector2 (0, -2);
    }
}
