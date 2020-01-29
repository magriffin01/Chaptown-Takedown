using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverDown : MonoBehaviour
{
       //public Rigidbody2D platform;
    public Transform platform;
    

    public GameObject platform2;
    public float ThrustUp = 0;

    bool activateor = true;
    Vector3 pizza;
    void Start()
    {
        pizza = new Vector3 (0,-5,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        platform.Translate(pizza);
        col.transform.SetParent(platform2.transform);
       // platform.AddForce(transform.up * ThrustUp);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col.transform.SetParent(null);
        //platform.AddForce(transform.up * -600f);
    }
}
