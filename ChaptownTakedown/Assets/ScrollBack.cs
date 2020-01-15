using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack : MonoBehaviour
{
    public float speed = -5f;
    public Vector2 ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed, 20);
        transform.position = ground +Vector2.right * newPos;
    }
}
