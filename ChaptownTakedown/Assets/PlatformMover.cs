using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Rigidbody2D platform;

    public float ThrustUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        platform.AddForce(transform.up * ThrustUp);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        platform.AddForce(transform.up * -90f);
    }
}
