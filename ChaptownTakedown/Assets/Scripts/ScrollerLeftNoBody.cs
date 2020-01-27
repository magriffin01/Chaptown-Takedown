using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerLeftNoBody : MonoBehaviour
{
    public float speed = 0f;
    Vector3 mover = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
	{
        mover = new Vector3(speed, 0, 0);
    }

	// Update is called once per frame
	void Update()
	{
		transform.Translate(mover * Time.deltaTime);
	}
}