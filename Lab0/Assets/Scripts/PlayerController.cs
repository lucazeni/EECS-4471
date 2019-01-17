using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    // Use this for initialization
    Vector3 movement = new Vector3();
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        
        rb.AddForce(moveHorizontal * 5, 0.0f * 5, moveVertical * 5);
    }
}
