using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    //public Rigidbody2D platform;
    public Transform platform;
    public float ThrustUp = 0;

    public GameObject platform2;

    bool activateor = true;
    Vector3 pizza;
    // Start is called before the first frame update
    void Start()
    {
        pizza = new Vector3 (0,5,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.SetParent(platform2.transform);
        col.transform.SetParent(null);
        platform.Translate(pizza);
       // platform.AddForce(transform.up * ThrustUp);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //platform.AddForce(transform.up * -600f);
    }
}
