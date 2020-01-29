using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    [SerializeField]
    GameObject platform;

    void OnTriggerEnter2D(Collider2D col)
    {
        // platform.transform.position += new Vector3 (0, 3);
        nextPos = pos1.position;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // platform.transform.position += new Vector3 (0, -3);
        nextPos = pos2.position;
    }

    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, nextPos, speed * Time.deltaTime);
    }

    void Start()
    {
        nextPos = startPos.position;
    }
}
